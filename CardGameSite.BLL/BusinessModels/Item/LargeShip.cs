using System;
using Model.Item.Interface;
using System.Data.Linq.Mapping;

namespace Model.Item {

	[Table(Name = "LargeShip")]
	public class LargeShip : Card , IShip  {
		public IModule[] Modules { get; init; }
		[Column]
		public override int Cost { get; init; }
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public override int Id { get; init; }
		[Column]
		public override string Name { get; set; }
		[Column]
		public override string ImagePath { get; init; }
		[Column]
		public override string Description { get; init; }
		[Column]
		public int Attack { get; set; }
		[Column]
		public int Armor { get; init; }
		[Column]
		public int Shield { get; init; }

		public IModule GetModule(int index) {
			try
			{
				return Modules[index];
			}
			catch (IndexOutOfRangeException e)
			{
				return null;
			}
		}
		public bool SetModule(int index, IModule module) {
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
		public bool? HasModule(int index) {
			try {
				return Modules[index] != null ? true : false;
			} 
			catch (IndexOutOfRangeException e) {
				return null;
            }
			 
		}
		public LargeShip(int id):base(id) {
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
