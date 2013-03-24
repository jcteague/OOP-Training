using System.Collections.Generic;
using System.IO;

namespace CodeCamp2008.DIP
{
    public interface IFileRepository
    {
        IEnumerable<Product> GetAllProduct();
    }

    public class FileRepository : IFileRepository
    {
        public IEnumerable<Product> GetAllProduct()
        {
            IList<Product> products = new List<Product>();
            StreamReader reader = new StreamReader("Product.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split('\t');
                products.Add(new Product(int.Parse(items[0]), items[1], items[2]));
            }
            reader.Close();
            return products;
        }
    }




    public class InMemoryRepository : IFileRepository
    {
        public IEnumerable<Product> GetAllProduct()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product(10, "Laptop", "Computer"));
            products.Add(new Product(20, "Desktop", "Computer"));
            products.Add(new Product(30, "webcam", "Computer"));
            products.Add(new Product(40, "camera", "Electronic"));
            products.Add(new Product(50, "iPod", "Electronic"));
            
            return products;
        }
    }
}