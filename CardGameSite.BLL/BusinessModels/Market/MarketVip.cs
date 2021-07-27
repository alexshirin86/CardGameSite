using System;
using System.Collections.Generic;
using Model.Interfaces;

namespace Model {
	public class MarketVip : MarketPlayer
    {

        public MarketVip(IAccount account)
        {

            Trash trash = new Trash();
            Account = account;
            Console.WriteLine("Магазин для вип игроков");
        }

        public new void ShowProducts(){

			base.ShowProducts();
			Console.WriteLine("Предложения для вип игроков");
			List<ProductDB> products = DB.GetProductsMarketVip();
	
			int i = 1;
			foreach (ProductDB product in products) {
				Console.WriteLine( $"{i}. {product.Name} {product. Price}. Доступная скидка {Account.Disscount}.");
				i++;
			}
	
			Console.WriteLine("\n");
		}

	}

}