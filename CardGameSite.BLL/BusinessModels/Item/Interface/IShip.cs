using System;

namespace CardGameSite.BLL.BusinessModels.Item.Interface
{
	public interface IShip
	{
		IModule[] Modules { get; }
		int Attack { get; }
		int Armor { get; }
		int Shield { get; }

		IModule GetModule(int index);
		bool SetModule(int index, IModule module);
		bool? HasModule(int index);

	}

}
