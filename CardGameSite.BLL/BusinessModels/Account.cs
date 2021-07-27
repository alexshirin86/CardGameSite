using Model.Interfaces;

namespace Model {
	public class Account : IAccount  {
		public int Money { get; set; }
		public EnumTypeAccount TypeAccount { get; init; }
		public string Name { get; init; }
		public int Disscount { get; init; }
		public int Id { get; init; }

		public Account(int id, EnumTypeAccount typeAccount) {
			Money = DB.GetMoney(id);
			Disscount = DB.GetDisscount(id);
			TypeAccount = typeAccount;
		}
		public void AddFunds(int number, int month, int year, int cash) {
			DB.SetMoney(Id, cash);
		}
		public void AddFunds(string email, int pnumber, int cash) {
			DB.SetMoney(Id, cash);
		}
		public int GetIdGameDeck() {
			throw new System.NotImplementedException("Not implemented");
		}


	}

}
