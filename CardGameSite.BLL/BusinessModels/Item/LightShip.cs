using System;
using CardGameSite.BLL.BusinessModels.Item.Interface;


namespace CardGameSite.BLL.BusinessModels.Item 
{

	public class LightShip : Card , IShip 
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
			try
			{
			   	return Modules[index] != null ? true : false;
			} 
			catch (IndexOutOfRangeException e) 
			{
				return null;
			}
		}

		public LightShip(int id):base(id) 
		{
			Modules = new IModule[1];
		}

		public bool SetModule(IModule module) 
		{
			Modules[0] = module;
			return true;
		}

		public bool? HasModule() 
		{
			return Modules[0] != null ? true : false;
		}

		public IModule GetModule() 
		{
			return Modules[0];
		}

	}

}
