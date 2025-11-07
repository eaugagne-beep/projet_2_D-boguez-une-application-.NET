using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
     
        public List<Product> GetAllProducts() //ajout List
        {

            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>

        
        public Product GetProductById(int id)
        {
            //ajout de la methode

            return _productRepository.GetProductById(id);
        }
        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>

        public void UpdateProductQuantities(Cart cart)
        //ajout de la methode
        {
            foreach (var line in cart.Lines)
            {
                var product = line.Product;


                _productRepository.UpdateProductStocks(product.Id, line.Quantity);
            }
        }
    }
}
