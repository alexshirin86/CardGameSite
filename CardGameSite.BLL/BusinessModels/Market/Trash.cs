using CardGameSite.BLL.BusinessModels.Item;
using System.Collections.Generic;

namespace CardGameSite.BLL.BusinessModels 
{
	public class Trash
    {

        public decimal Sum { get; private set; }

        private List <Product> _products;

		public Trash(){

			Sum = 0;
		}

		public void Pay(){

		}
            

        public void Add(Product product)
        {

            _products.Add(product);
            Sum += product.Price;
        }

        public void Remove(Product product)
        {

            _products.Remove(product);
            Sum -= product.Price;
        }

        public void Clear(){

			_products.Clear();
			Sum = 0;
		}

	}

}