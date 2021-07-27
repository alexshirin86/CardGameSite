using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Interfaces;
using CardGameSite.BLL.BusinessModels.Item;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;

namespace CardGameSite.BLL.BusinessModels
{
	public class MarketPlayer : IMarket {

		protected internal Trash _trash;

		public MarketPlayer(){

			Trash trash = new Trash();
		}

        public MarketPlayer(IAccount account)
        {

            Trash trash = new Trash();
            Account = account;
        }

        public IAccount Account{ get; }

		public List<Product> GetProducts()
		{

			List<Product> products = DB.GetProductsMarketPlayer();

			return products;

		}

		public void AddInTrash(){

		}

	}

}