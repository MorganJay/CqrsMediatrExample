namespace CqrsMediatrExample
{
    public class FakeDataStore
    {
        private static List<Product> _products;

        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product{ Id = 1, Name = "Test Product 1"},
                new Product{ Id = 2, Name = "Test Product 2"},
                new Product{ Id = 3, Name = "Test Product 3"},
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);
        public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.SingleOrDefault(p => p.Id == id));

        public async Task DeleteProduct(int id)
        {
            var productToRemove = await GetProductById(id);

            _products.Remove(productToRemove);

            await Task.CompletedTask;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var indexOfProductToUpdate = _products.FindIndex(p => p.Id == id);

            _products[indexOfProductToUpdate].Name = product.Name;

            await Task.CompletedTask;

            return _products[indexOfProductToUpdate];
        }        

        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";

            await Task.CompletedTask;
        }
    }
}
