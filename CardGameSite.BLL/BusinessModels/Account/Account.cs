using CardGameSite.BLL.BusinessModels.Enums;
using CardGameSite.BLL.BusinessModels.Account.Interfaces;

namespace CardGameSite.BLL.BusinessModels.Account
{
	public class Account : IAccount  
	{
		public int Cash { get; set; }
		public EnumTypeAccount TypeAccount { get; }
		public string Name { get; }
		public int Disscount { get; }
		public int Id { get; }
		 
		public Account(int id, EnumTypeAccount typeAccount) {
			//Money = DB.GetMoney(id);
			//Disscount = DB.GetDisscount(id);
			//TypeAccount = typeAccount;
		}
		public void AddFunds(int number, int month, int year, int cash) {
			//DB.SetMoney(Id, cash);
		}
		public void AddFunds(string email, int pnumber, int cash) {
			//DB.SetMoney(Id, cash);
		}
		public int GetIdGameDeck() {
			throw new System.NotImplementedException("Not implemented");
		}


	}

}
