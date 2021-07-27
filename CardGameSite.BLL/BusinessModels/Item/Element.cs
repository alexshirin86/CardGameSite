using System;
using System.Data.Linq;

namespace Model.Item {
	[Serializable]
	public abstract class Element: DataContext {
		public abstract int Id { get; init; }
		public abstract string Name { get; set; }
		public abstract string ImagePath { get; init; }

	}

}