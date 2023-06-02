using MVC.Models;
public class ProductService
{
    private List<ProductModel> products = new List<ProductModel>();
    public ProductService()
    {
        LoadProducts();
    }
    public ProductModel Find(int id)
    {
        var qr = (from p in products
                  where p.ProId == id
                  select p).FirstOrDefault();
        return qr;
    }
    public List<ProductModel> AllProduct() => products;
    public void LoadProducts()
    {
        products.Clear();
        products.AddRange(new List<ProductModel>() {
            new ProductModel(){ProId = 1, Name = "BBQ Burger", Description = "San xuat boi apple", Price=1000, CateId = 1},
            new ProductModel(){ProId = 2, Name = "Black Burger", Description = "San xuat boi Samsung", Price=900, CateId = 1},
            new ProductModel(){ProId = 3, Name = "Chicken Burger", Description = "San xuat boi Nokia", Price=200, CateId = 1},
            new ProductModel(){ProId = 4, Name = "Smoked Meat Burger", Description = "San xuat boi Xiaomi", Price=500, CateId = 1},
            new ProductModel(){ProId = 5, Name = "Teriyaki Chicken Burger", Description = "San xuat boi Asus", Price=1500, CateId = 1},
            new ProductModel(){ProId = 6, Name = "Turkey Burger", Description = "San xuat boi apple", Price=1000, CateId = 1},
            new ProductModel(){ProId = 7, Name = "Tomato Pizza", Description = "San xuat boi Samsung", Price=900, CateId = 2},
            new ProductModel(){ProId = 8, Name = "Sea Food Pizza", Description = "San xuat boi Nokia", Price=200, CateId = 2},
            new ProductModel(){ProId = 9, Name = "Pepperoni Pizza", Description = "San xuat boi Xiaomi", Price=500, CateId = 2},
            new ProductModel(){ProId = 10, Name = "Vegetable Pizza", Description = "San xuat boi Asus", Price=1500, CateId = 2},
            new ProductModel(){ProId = 11, Name = "Coke", Description = "San xuat boi apple", Price=1000, CateId = 3},
            new ProductModel(){ProId = 12, Name = "Banana Juice", Description = "San xuat boi Samsung", Price=900, CateId = 3},
            new ProductModel(){ProId = 13, Name = "Orange Juice", Description = "San xuat boi Nokia", Price=200, CateId = 3},
            new ProductModel(){ProId = 14, Name = "Xiaomi Red", Description = "San xuat boi Xiaomi", Price=500, CateId = 4},
            new ProductModel(){ProId = 15, Name = "ROG Phone 5", Description = "San xuat boi Asus", Price=1500, CateId = 5}
        });
    }

}