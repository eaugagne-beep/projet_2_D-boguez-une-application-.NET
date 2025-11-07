using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        
        public IEnumerable<CartLine> Lines => lines;

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>

        private List<CartLine> lines = new List<CartLine>(); // supression de  GetCartLineList()
        
        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        
        public void AddItem(Product product, int quantity)
        {
            // ajout de la methode

            var line = lines.FirstOrDefault(l => l.Product.Id == product.Id);
            if (line == null)
            {
                lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        /// <summary>
        /// Removes a product form the cart
        /// </summary>

        public void RemoveLine(Product product) =>
             
            lines.RemoveAll(l => l.Product.Id == product.Id); // supression de  GetCartLineList()



        /// <summary>
        /// Get total value of a cart
        /// </summary>

        public double GetTotalValue()
        {
            // ajout methode

            return lines.Sum(l => l.Product.Price * l.Quantity);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            if (Lines == null || !Lines.Any())
                return 0;

            double totalValue = Lines.Sum(l => l.Product.Price * l.Quantity);
            double totalQuantity = Lines.Sum(l => l.Quantity);

            return totalQuantity == 0 ? 0 : totalValue / totalQuantity;
        }





        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // ajout methode

            return lines.FirstOrDefault(l => l.Product.Id == productId)?.Product;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        /// /// <summary>/// Vide le panier de tous les produits ajoutés/// </summary>
        public void Clear()
        {
       
            lines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
