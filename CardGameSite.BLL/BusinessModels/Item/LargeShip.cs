using System;
using CardGameSite.BLL.BusinessModels.Item.Interface;

namespace CardGameSite.BLL.BusinessModels.Item 
{

	public class LargeShip : Card, IShip 
	{
		public IModule[] Modules { get; protected set; }

		public override int Cost { get; protected set; }

		public override int Id { get; protected set; }

		public override string Name { get; protected set; }

		public override string Description { get; protected set; }

		public int Attack { get; protected set; }

		public int Armor { get; protected set; }

		public int Shield { get; protected set; }

		public IModule GetModule(int index)
		{
			try
			{
				return Modules[index];
			}
			catch (IndexOutOfRangeException)
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
			catch (IndexOutOfRangeException)
			{
				return false;
			}
		}

		public bool? HasModule(int index)
		{
			try {
				return Modules[index] != null;
			} 
			catch (IndexOutOfRangeException) {
				return null;
            }
			 
		}

		public LargeShip(int id, string name, string description) : base(id, name, description) {
            Modules = new IModule[3];
		}

		public LargeShip(int id, string name, string description, int cost, int attack, int armor, int shield): base(id, name, description)
		{
			Modules = new IModule[3];
			Cost = cost;
			Attack = attack;
			Armor = armor;
			Shield = shield;
		}
	}
}
