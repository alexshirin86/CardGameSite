using System;

namespace Model.Item.Interface {
	public interface IShip {
		IModule[] Modules { get; init; }
		int Attack { get; set; }
		int Armor { get; init; }
		int Shield { get; init; }

		IModule GetModule(int index);
		bool SetModule(int index, IModule module);
		bool? HasModule(int index);

	}

}
