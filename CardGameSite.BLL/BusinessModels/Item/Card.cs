using System;

namespace Model.Item {
	public abstract class Card : Element  {
		public abstract string Description { get; init; }
		public override abstract int Id { get; init; }
		public override abstract string ImagePath { get; init; }
		public override abstract string Name { get; set; }
		public abstract int Cost { get; init; }

		public Card(int id) {
			Id = id;
			CardDB card = DB.GetCard( id );
			Name = card.Name;
			Description = card.Flavour;
		}

		public Card(string name, string imagePath, string description)
		{
			ImagePath = imagePath;
			Name = name;
			Description = description;
		}



	}

}
