using System;
using CardGameSite.BLL.BusinessModels.Item.Interface;

namespace CardGameSite.BLL.BusinessModels.Item 
{

	public class LargeShip : Card , IShip 
	{
		public IModule[] Modules { get; }

		public override int Cost { get; }

		public override int Id { get; }

		public override string Name { get; set; }

		public override string ImagePath { get; }

		public override string Description { get; }

		public int Attack { get; set; }

		public int Armor { get; }

		public int Shield { get; }

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

		public bool? HasModule(int index)
		{
			try {
				return Modules[index] != null ? true : false;
			} 
			catch (IndexOutOfRangeException e) {
				return null;
            }
			 
		}

		public LargeShip(int id) : base(id) {
            Modules = new IModule[3];
		}

		public LargeShip(int cost, int attack, int armor, int shield, string name, string imagePath, string description): base(name, imagePath, description)
		{
			Cost = cost;
			Attack = attack;
			Armor = armor;
			Shield = shield;
		}
	}
}
