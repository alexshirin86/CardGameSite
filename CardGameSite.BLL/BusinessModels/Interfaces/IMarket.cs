using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Item;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;

namespace CardGameSite.BLL.BusinessModels.Interfaces 
{
	public interface IMarket  
	{
		IAccount Account{ get; }

		List<Product> GetProducts();
	}
}