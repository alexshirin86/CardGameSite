using System;
using CardGameSite.BLL.BusinessModels.Item.Interface;


namespace CardGameSite.BLL.BusinessModels.Item
{

	public class MediumShip : Card , IShip 
	{
		public IModule[] Modules { get; }		

		public override int Id { get; }

		public override string Name { get; set; }

		public override string ImagePath { get; }

		public override string Description { get; }

		public int Attack { get; set; }

		public int Armor { get; }

		public int Shield { get; }

		public override int Cost { get; }

		public bool? HasModule(int index)
		{
			try
			{
				return Modules[index] != null ? true : false;
			}
			catch (IndexOutOfRangeException e)
			{
				return null;
			}
		}
		public bool SetModule(int index, IModule module)
		{
			try
			{
				Modules[index] = module;
				return true;
			}
			catch (IndexOutOfRangeException e)
			{
				return false;
			}
		}

		public IModule GetModule(int index) 
		{
			try
			{
				return Modules[index];
			}
			catch (IndexOutOfRangeException e)
			{
				return null;
			}
		}

		public MediumShip(int id): base(id) 
		{
			Modules = new IModule[2];
		}

	}

}
