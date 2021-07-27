
namespace CardGameSite.BLL.BusinessModels.Account.Interfaces
{
    public interface IAccount
	{
		string Name { get; }
		int Disscount { get;}
		EnumTypeAccount TypeAccount { get; }
		int Id { get; }

		int GetIdGameDeck();

	}

}
