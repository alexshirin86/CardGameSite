using System;
using Model.Interfaces;

namespace Model {
	public class Game {

		private IAccount _account;
		private IMarket _market;


        public bool Login(string name, string pass)
        {

            if (DB.HasUser(name, pass))
            {
                Launch(name);
                return true;
            }
            return false;
        }


        public bool NewAccount(string name, string pass)
        {

            return DB.NewAccount(name) ? Login(name, pass) : false;
        }


        private void Launch(string name)
        {

            Console.WriteLine($"\nДобро пожаловать, {name}!");
            Console.WriteLine("Вам доступно:");
            Console.Write("1. ");

            EnumTypeAccount typeAccount = DB.GetTypeAccount(name);
            _account = new Account(DB.GetId(name), typeAccount);

            if (typeAccount == EnumTypeAccount.Admin)
            {
                _market = new MarketAdmin(_account);
            }
            else if (typeAccount == EnumTypeAccount.Player)
            {
                _market = new MarketPlayer(_account);
            }
            else if (typeAccount == EnumTypeAccount.Vip)
            {
                _market = new MarketVip(_account);
            }

            Console.WriteLine("2. Играть партию");
            Console.WriteLine("3. Выход");

            string command;
            do
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        _market.ShowProducts();
                        break;
                    case "2":
                        Model.PartyGame.Game game = new Model.PartyGame.Game(_account, _account);
                        break;
                    case "3":
                        Unlogin();
                        break;
                    default:
                        Console.WriteLine("Попробуйте еще раз или введите 3 для выхода.");
                        break;
                }
            } while (!Exit);
        }

        private void Unlogin(){

		}

        public bool Exit {
            get; set;
        }

        public Game()
        {
			Exit = false;
		}

	}

}