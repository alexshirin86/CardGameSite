using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;
using CardGameSite.BLL.BusinessModels.Item;
using System.Linq;

namespace CardGameSite.BLL.BusinessModels
{
	public class MarketVip : MarketPlayer
    {

        public MarketVip(IAccount account) : base (account)
        {

        }

        public new List<Product> GetProducts()
		{
            			
			List<Product> productsPlayers = base.GetProducts();
            List<Product> products = productsPlayers.Union( new List<Product>()).ToList<Product>();

            return products;
		}

	}

}