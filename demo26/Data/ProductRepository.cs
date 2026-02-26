using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using demo26;


namespace demo26
{
    public class ProductRepository
    {
        
        static string conn = @"Data Source=(localdb)\test;Initial Catalog=Demo26.2;Integrated Security=true";
        //SqlConnection con = new SqlConnection(conn);
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
                FROM [dbo].[Товар];
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
                            ImagePath = Convert.ToString(r["ImagePath"])
                        });
                    }
                }
                
            }

            return list;
        }
    }
}
