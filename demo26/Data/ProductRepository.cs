using demo26;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;


namespace demo26
{
    public class ProductRepository
    {

        static string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo26;Integrated Security=true";

        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using (SqlConnection con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                SELECT
                    [id товара] AS Id,
                    [Артикул] AS Article,
                    [Наименование товара] AS Name,
                    [Категория товара] AS Category,
                    [Описание товара] AS Description,
                    [Производитель] AS Manufacturer,
                    [Поставщик] AS Supplier,
                    CAST([Цена] AS decimal(18,2)) AS Price,
                    [Единица измерения] AS Unit,
                    [Кол-во на складе] AS StockQty,
                    CAST(ISNULL([Действующая скидка],0) AS decimal(18,2)) AS DiscountPercent,
                    [Фото] AS ImagePath
                FROM [dbo].[Tovar];
            ", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Product
                        {
                            Id = Convert.ToInt32(r["Id"]),
                            Article = Convert.ToString(r["Article"]),
                            Name = Convert.ToString(r["Name"]),
                            Category = Convert.ToString(r["Category"]),
                            Description = Convert.ToString(r["Description"]),
                            Manufacturer = Convert.ToString(r["Manufacturer"]),
                            Supplier = Convert.ToString(r["Supplier"]),
                            Price = Convert.ToDecimal(r["Price"]),
                            Unit = Convert.ToString(r["Unit"]),
                            StockQty = Convert.ToInt32(r["StockQty"]),
                            DiscountPercent = Convert.ToDecimal(r["DiscountPercent"]),
                            ImagePath = Convert.ToString(r["ImagePath"]),
                        });
                    }
                }

            }

            return list;
        }
        public void Add(Product product)
        {
            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                INSERT INTO [dbo].[Tovar]
                (
                    [Артикул],
                    [Наименование товара],
                    [Категория товара],
                    [Описание товара],
                    [Производитель],
                    [Поставщик],
                    [Единица измерения],
                    [Цена],
                    [Действующая скидка],
                    [Кол-во на складе]
                )
                VALUES
                (
                    @Article,
                    @Name,
                    @Category,
                    @Description,
                    @Manufacturer,
                    @Supplier,
                    @Unit,
                    @Price,
                    @Discount,
                    @StockQty
                )
            ", con))
            {
                cmd.Parameters.AddWithValue("@Article", product.Article);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Category", (object)product.Category ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)product.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Manufacturer", (object)product.Manufacturer ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Supplier", (object)product.Supplier ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Unit", (object)product.Unit ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Discount", product.DiscountPercent);
                cmd.Parameters.AddWithValue("@StockQty", product.StockQty);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool IsProductUsedInOrders(int productId)
        {
            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
        SELECT COUNT(*)
        FROM [dbo].[Позиция]
        WHERE [Id товара] = @Id
    ", con))
            {
                cmd.Parameters.AddWithValue("@Id", productId);
                con.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public void Delete(int productId)
        {
            if (IsProductUsedInOrders(productId))
                throw new InvalidOperationException("Нельзя удалить товар, который присутствует в заказе.");

            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
        DELETE FROM [dbo].[Tovar]
        WHERE [id товара] = @Id
    ", con))
            {
                cmd.Parameters.AddWithValue("@Id", productId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Product product)
        {
            using (var con = new SqlConnection(conn))
            using (var cmd = new SqlCommand(@"
                UPDATE [dbo].[Tovar]
                SET
                    [Артикул] = @Article,
                    [Наименование товара] = @Name,
                    [Категория товара] = @Category,
                    [Описание товара] = @Description,
                    [Производитель] = @Manufacturer,
                    [Поставщик] = @Supplier,
                    [Единица измерения] = @Unit,
                    [Цена] = @Price,
                    [Действующая скидка] = @Discount,
                    [Кол-во на складе] = @StockQty
                WHERE [id товара] = @Id
            ", con))
            {
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@Article", product.Article);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Category", (object)product.Category ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)product.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Manufacturer", (object)product.Manufacturer ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Supplier", (object)product.Supplier ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Unit", (object)product.Unit ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Discount", product.DiscountPercent);
                cmd.Parameters.AddWithValue("@StockQty", product.StockQty);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        } 
    }
}
