using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Interfaces;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;
using CardGameSite.BLL.BusinessModels.Item;

namespace CardGameSite.BLL.BusinessModels
{
	public class MarketAdmin : IMarket
	{

        public MarketAdmin(IAccount account)
        {
            Account = account;            
        }

        public IAccount Account { get; }

		public List<Product> GetProducts()
		{
			List<Product> products = DB.GetProductsMarketAdmin();

			return products;
		}

	}
}