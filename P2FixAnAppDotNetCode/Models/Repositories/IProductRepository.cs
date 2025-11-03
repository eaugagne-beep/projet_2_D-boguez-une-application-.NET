using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(); // ajout List
        Product GetProductById(int id); // Ajout de la méthode pour récupérer un produit
        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
