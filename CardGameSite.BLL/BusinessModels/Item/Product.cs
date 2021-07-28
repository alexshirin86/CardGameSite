using CardGameSite.BLL.BusinessModels.Enums;

namespace CardGameSite.BLL.BusinessModels.Item 
{

	public class Product : Element 
	{

		public int GoldCount { get; }

		public int CrystalCount { get; }

		private Card[] _card;
		public override int Id { get; protected set; }
		public override string Name { get; protected set; }
		public override string Description { get; protected set; }
		public decimal Price { get; }
		public EnumCategoriesProduct Category { get; }

		
		public Product( int id, string name, string description, decimal price, EnumCategoriesProduct category) : 
			base(id, name, description)
		{
			Price = price;
			Category = category;
		}

	}

}
