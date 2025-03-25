internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IRepository<Product> repository = new ProductRepository();

        // Add products
        repository.Add(new Product { Id = 1, Name = "Product A" });
        repository.Add(new Product { Id = 2, Name = "Product B" });

        // Display all products
        foreach (var product in repository.GetAll())
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}");
        }

        // Find a product by ID
        var productById = repository.GetById(1);
        Console.WriteLine($"Found: ID: {productById.Id}, Name: {productById.Name}");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T Entity);
    void Remove(T Entity);
}

public class ProductRepository : IRepository<Product>
{
    private List<Product> _products = new List<Product>();
    void IRepository<Product>.Add(Product Entity)
    {
        _products.Add(Entity);
    }

    IEnumerable<Product> IRepository<Product>.GetAll()
    {
        return _products;
    }

    Product IRepository<Product>.GetById(int id)
    {
        return _products.FirstOrDefault(p=>p.Id == id);
    }

    void IRepository<Product>.Remove(Product Entity)
    {
        _products.Remove(Entity);
    }
}