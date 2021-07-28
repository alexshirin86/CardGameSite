using CardGameSite.BLL.BusinessModels.Enums;


namespace CardGameSite.BLL.BusinessModels.Item
{
	public abstract class Card : Element 
	{
		public override abstract int Id { get; protected set; }
		public override abstract string Name { get; protected set; }
		public override abstract string Description { get; protected set; }
		public abstract int Cost { get; protected set; }

		public Card(int id, string name, string description) : base(id, name, description){}
			
}

}
