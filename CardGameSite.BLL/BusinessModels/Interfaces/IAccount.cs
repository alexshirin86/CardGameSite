using System;

namespace Model.Interfaces {
	public interface IAccount {
		string Name { get; init; }
		int Disscount { get; init; }
		Model.EnumTypeAccount TypeAccount { get; init; }
		int Id { get; init; }

		int GetIdGameDeck();

	}

}
