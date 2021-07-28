using System;


namespace CardGameSite.BLL.BusinessModels.Item
{
	public abstract class Element
	{
		public abstract int Id { get; protected set; }
		public abstract string Name { get; protected set; }
		public abstract string Description { get; protected set; }

		public Element(int id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public Element(){}
	}
}