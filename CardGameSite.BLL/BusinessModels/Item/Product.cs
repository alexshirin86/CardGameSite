namespace CardGameSite.BLL.BusinessModels.Item 
{

	public class Product : Element 
	{

		public int GoldCount { get; }

		private int CrystalCount { get; }
		public int Price { get; }
		public override string Name { get; set; }
		private Card[] card;
		public override string ImagePath { get; }
		public override int Id { get; }

        Product(int id)
        {
			Id = id;

		}

	}

}
