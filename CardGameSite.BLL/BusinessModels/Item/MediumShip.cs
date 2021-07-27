using System;
using Model.Item.Interface;
using System.Data.Linq.Mapping;

namespace Model.Item {
	[Table(Name = "MediumShip")]
	public class MediumShip : Card , IShip  {
		public IModule[] Modules { get; init; }		
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
		[Column]
		public override int Cost { get; init; }

		public bool? HasModule(int index) {
			try
			{
				return Modules[index] != null ? true : false;
			}
			catch (IndexOutOfRangeException e)
			{
				return null;
			}
		}
		public bool SetModule(int index, Model.Item.Interface.IModule module) {
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
		public Model.Item.Interface.IModule GetModule(int index) {
			try
			{
				return Modules[index];
			}
			catch (IndexOutOfRangeException e)
			{
				return null;
			}
		}
		public MediumShip(int id): base(id) {
			Modules = new IModule[2];
		}

	}

}
