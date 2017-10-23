using System; 
using System.Linq;

namespace ErDat
{
    class ErDat 
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" hej program");

            using (var db = new NorthwindContent())
            {
                
                var categories = db.Categories.Where(x => x.Id < 8).ToList();
                var Orders = db.Orders.Where(x => x.Id < 10256).ToList();
                var Products = db.Products.Where(x => x.Id < 8).ToList();

                var Orderdetails = db.Orderdetails.Where(x => x.Id < 10251).ToList();

                // udskriver liste
                categories.ForEach(c => Console.WriteLine("Hej cat {0}", ": " + c.Id + " " + c.Name + " " + c.Description));
                Orders.ForEach(d => Console.WriteLine("Hej orders {0}", ": " + d.Id + " " + d.CustomerId + " " + d.ShipAddress + " " + d.ShipCity + " " + d.ShipCountry + " " + d.ShipName + " " + d.ShippedDate + " " + d.ShipPostalCode));
                Products.ForEach(a => Console.WriteLine("Hej products {0}", ": " + a.Id + " " + a.ProductName + " " + a.QuantityUnit + " " + a.SupplierId + " " + a.UnitPrice + " " + a.UnitsInStock + " " + a.CategoryId));

                foreach (var orderdetail in Orderdetails)
                {
                    Console.WriteLine("var orderdetail: " + orderdetail.Id + " " + orderdetail.ProductId + " " + orderdetail.UnitPrice + " " + orderdetail.Quantity + " " + orderdetail.UnitPrice);
                }

                /*

                foreach (var product in Products)
                {
                    Console.WriteLine("from var Product: " + product.Id + " " + product.ProductName + " " + product.QuantityUnit + " "
                                       + product.SupplierId + " " + product.UnitPrice + " " + product.UnitsInStock);
                }


                */


                db.SaveChanges();

                


            }

        }
    }
}


/*
 
-------------------------------------------------
// find a specifik categoryid
var category = db.Categories.FirstOrDefault(x => x.Id == 11);
-------------------------------------------
// update
if (category != null)
{
category.Name = "Testing fish";
}
db.SaveChanges();

--------------------------------------------
// delete
var category = db.Categories.FirstOrDefault(
   x => x.Id == 12);

db.Categories.Remove(category)

---------------------------------------
// New category
var category = new Category
{
    Name = "fish",
    Description = "Testing"
};
---------------------------------------
db.Categories.Add(category);
db.SaveChanges();

 --------------------------------------
 

              
 -------------------------------------------

     */
