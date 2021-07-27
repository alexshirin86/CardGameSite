using System;
using System.Data.Linq.Mapping;

namespace Model.Item {
	[Table(Name = "Product")]
	public class Product : Element  {
		[Column]
		public int GoldCount { get; init; }
		[Column]
		private int CrystalCount { get; init; }
		public int Price { get; }
		[Column]
		public override string Name { get; init; }
		private Card[] card;
		[Column]
		public override string ImagePath { get; init; }
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public override int Id { get; init; }

        Product(int id)
        {
			Id = id;

		}


	}

}
