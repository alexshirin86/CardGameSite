using System;


namespace CardGameSite.BLL.BusinessModels.Item
{
	[Serializable]
	public abstract class Element
	{
		public abstract int Id { get; }
		public abstract string Name { get; set; }
		public abstract string ImagePath { get; }

	}

}