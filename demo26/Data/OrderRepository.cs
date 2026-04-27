using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace demo26
{
    public class OrderRepository
    {
        private static readonly string conn =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo26.2;Integrated Security=true";

        public List<Order> GetAll()
        {
            var list = new List<Order>();

            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                SELECT
                    z.[Номер заказа] AS Id,
                    ISNULL((
                        SELECT TOP 1 p.[Артикул]
                        FROM [dbo].[Позиция] p
                        WHERE p.[Id заказа] = z.[Номер заказа]
                    ), '') AS Article,
                    z.[Статус заказа] AS Status,
                    z.[Адрес пункта выдачи] AS PickupPointId,
                    z.[Дата заказа] AS OrderDate,
                    z.[Дата доставки] AS DeliveryDate
                FROM [dbo].[Заказы] z
                ORDER BY z.[Номер заказа] DESC
            ", con))
            {
                con.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Order
                        {
                            Id = Convert.ToInt32(r["Id"]),
                            Article = Convert.ToString(r["Article"]),
                            Status = Convert.ToString(r["Status"]),
                            PickupPointId = Convert.ToInt32(r["PickupPointId"]),
                            OrderDate = Convert.ToDateTime(r["OrderDate"]),
                            DeliveryDate = Convert.ToDateTime(r["DeliveryDate"])
                        });
                    }
                }
            }

            return list;
        }

        public List<int> GetPickupPoints()
        {
            var list = new List<int>();

            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                SELECT [id пункта]
                FROM [dbo].[Пункты выдачи]
                ORDER BY [id пункта]
            ", con))
            {
                con.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        list.Add(Convert.ToInt32(r[0]));
                }
            }

            return list;
        }

        public List<string> GetStatuses()
        {
            return new List<string>
            {
                "Новый",
                "В обработке",
                "Готов к выдаче",
                "Выдан",
                "Отменён"
            };
        }

        public void Add(Order order)
        {
            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                INSERT INTO [dbo].[Заказы]
                (
                    [Дата заказа],
                    [Дата доставки],
                    [Адрес пункта выдачи],
                    [Фамилия клиента],
                    [Имя клиента],
                    [Отчество клиента],
                    [Код для получения],
                    [Статус заказа]
                )
                VALUES
                (
                    @OrderDate,
                    @DeliveryDate,
                    @PickupPointId,
                    N'Не указано',
                    N'Не указано',
                    NULL,
                    100,
                    @Status
                );

                SELECT SCOPE_IDENTITY();
            ", con))
            {
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate.Date);
                cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate.Date);
                cmd.Parameters.AddWithValue("@PickupPointId", order.PickupPointId);
                cmd.Parameters.AddWithValue("@Status", order.Status);

                con.Open();
                int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                if (!string.IsNullOrWhiteSpace(order.Article))
                    AddPosition(con, orderId, order.Article);
            }
        }

        public void Update(Order order)
        {
            using (var con = new SqlConnection(conn))
            {
                con.Open();

                using (var cmd = new SqlCommand(@"
                    UPDATE [dbo].[Заказы]
                    SET
                        [Дата заказа] = @OrderDate,
                        [Дата доставки] = @DeliveryDate,
                        [Адрес пункта выдачи] = @PickupPointId,
                        [Статус заказа] = @Status
                    WHERE [Номер заказа] = @Id
                ", con))
                {
                    cmd.Parameters.AddWithValue("@Id", order.Id);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate.Date);
                    cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate.Date);
                    cmd.Parameters.AddWithValue("@PickupPointId", order.PickupPointId);
                    cmd.Parameters.AddWithValue("@Status", order.Status);

                    cmd.ExecuteNonQuery();
                }

                using (var deleteCmd = new SqlCommand(@"
                    DELETE FROM [dbo].[Позиция]
                    WHERE [Id заказа] = @OrderId
                ", con))
                {
                    deleteCmd.Parameters.AddWithValue("@OrderId", order.Id);
                    deleteCmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(order.Article))
                    AddPosition(con, order.Id, order.Article);
            }
        }

        public void Delete(int orderId)
        {
            using (var con = new SqlConnection(conn))
            {
                con.Open();

                using (var cmd = new SqlCommand(@"
                    DELETE FROM [dbo].[Позиция]
                    WHERE [Id заказа] = @OrderId
                ", con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand(@"
                    DELETE FROM [dbo].[Заказы]
                    WHERE [Номер заказа] = @OrderId
                ", con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AddPosition(SqlConnection con, int orderId, string article)
        {
            int productId = GetProductIdByArticle(con, article);

            using (var cmd = new SqlCommand(@"
                INSERT INTO [dbo].[Позиция]
                (
                    [Id товара],
                    [Id заказа],
                    [Артикул],
                    [Количество]
                )
                VALUES
                (
                    @ProductId,
                    @OrderId,
                    @Article,
                    1
                )
            ", con))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.Parameters.AddWithValue("@Article", article);
                cmd.ExecuteNonQuery();
            }
        }

        private int GetProductIdByArticle(SqlConnection con, string article)
        {
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 [id товара]
                FROM [dbo].[Товар]
                WHERE LTRIM(RTRIM([Артикул])) = LTRIM(RTRIM(@Article))
            ", con))
            {
                cmd.Parameters.AddWithValue("@Article", article);

                object result = cmd.ExecuteScalar();

                if (result == null)
                    throw new Exception("Товар с указанным артикулом не найден.");

                return Convert.ToInt32(result);
            }
        }
    }
}