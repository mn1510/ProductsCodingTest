using CodingTest.DataModel;
using CodingTest.Interfaces;

namespace CodingTest.Repository
{
    public class ProductsRepo : IRepo<Product>
    {
        private List<Product> _products { get; set; }
        public List<Product> Products { get { return _products; }}
        public ProductsRepo()
        {
            _products = GenerateRandomProducts(5);
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetEntity(int id)
        {
            return _products.FirstOrDefault(a=>a.Id==id);
        }

        public List<Product> GenerateRandomProducts(int count)
        {
            Random random = new Random();
            List<Product> products = new List<Product>();

            Array productNames = Enum.GetValues(typeof(ProductName));
            Array productColours = Enum.GetValues(typeof(ProductColour));

            for (int i = 1; i <= count; i++)
            {
                Product product = new Product
                {
                    Id = i,
                    Name = (ProductName)Enum.ToObject(typeof(ProductName), random.Next(productNames.Length)),
                    Colour = (ProductColour)Enum.ToObject(typeof(ProductColour), random.Next(productColours.Length))
                };

                products.Add(product);
            }

            return products;
        }

    }

}
