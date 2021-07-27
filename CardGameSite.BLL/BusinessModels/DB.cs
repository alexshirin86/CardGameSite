
using System;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using System.Data;
using System.Collections.Generic;
using Model.Item;

namespace Model {
    public class DataBase : DataContext
    {
        public Table<LargeShip> LargeShipTable;
        public Table<LightShip> LightShipTable;
        public Table<MediumShip> MediumShipTable;
        public Table<Product> ProductTable;

        public DataBase(string connection) : base(connection) { }


    }
    public static class DB {

        public const string GDatabase = "GDatabase";
        public static string DirectoryApp = Directory.GetCurrentDirectory();
        public static string GDatabaseFile = $"{DirectoryApp}\\GDatabaseDB.mdf";
        public static string ConnectionString = $"Server = localhost\\SQLEXPRESS; Trusted_Connection=True; database = {GDatabase}";

        public static LargeShip LargeShipTable { get; private set; }
        public static LightShip LightShipTable { get; private set; }
        public static MediumShip MediumShipTable { get; private set; }

        public static Product ProductTable { get; private set; }

        public static DataContext DataDB;


        public static bool DropDatabase()
        {
            SqlConnection connection = new SqlConnection($"Server = localhost\\SQLEXPRESS; Trusted_Connection=True; database = master");

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = $"DROP DATABASE {GDatabase}";

                command.ExecuteNonQuery();

                command.CommandText = $"SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = '{GDatabase}'";
                Int32 count = (Int32) command.ExecuteScalar();

                return count > 0 ? true : false;             

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {                    
                    connection.Close();
                }

            }
        }

        public static void CreateDatabase()
        {
            
            SqlConnection connection = new SqlConnection($"Server = localhost\\SQLEXPRESS; Trusted_Connection=True; database = master");

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandText = $"CREATE DATABASE {GDatabase} ON PRIMARY " +
                "(NAME = GDatabase_Data, " +
                $"FILENAME = '{GDatabaseFile}', " +
                "SIZE = 10MB, MAXSIZE = 20MB, FILEGROWTH = 10%)";

                command.ExecuteNonQuery();

                Dictionary<string, string> dictColumns = new Dictionary<string, string>
                {
                    ["Attack"] = "INT",
                    ["Armor"] = "INT",
                    ["Shield"] = "INT",
                    ["Cost"] = "INT",
                    ["Name"] = "NVARCHAR(100)",
                    ["Description"] = "NVARCHAR(100)",
                    ["ImagePath"] = "NVARCHAR(100)",
                };

                Dictionary<string, string> dictColumnsProduct = new Dictionary<string, string>
                {
                    ["Attack"] = "INT",
                    ["Armor"] = "INT",
                    ["Shield"] = "INT",
                    ["Cost"] = "INT",
                    ["Name"] = "NVARCHAR(100)",
                    ["Description"] = "NVARCHAR(100)",
                    ["ImagePath"] = "NVARCHAR(100)",
                };

                command.CommandText = QueryCreatTable("LargeShip", dictColumns);
                command.ExecuteNonQuery();

                command.CommandText = QueryCreatTable("LightShip", dictColumns);
                command.ExecuteNonQuery();

                command.CommandText = QueryCreatTable("MediumShip", dictColumns);
                command.ExecuteNonQuery();

                command.CommandText = QueryCreatTable("Product", dictColumns);
                Console.WriteLine(command.ExecuteNonQuery());

                Console.WriteLine("БД создана.");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
        }

        public static string QueryCreatTable(string nameT, Dictionary<string, string> dictColumns)
        {
            string str = $"CREATE TABLE {nameT} (Id INT PRIMARY KEY IDENTITY, ";

            int i = 1;
            foreach (var column in dictColumns)
            {
                str += $"{column.Key} {column.Value} NOT NULL";

                if (i != dictColumns.Count)
                {
                    str += ", ";
                } else
                {
                    str += ")";
                }
                i++;
            }
            return str;
        }

        public static void OpenDatabase()
        {
            DataDB = new DataContext(ConnectionString);
            Table<LargeShip> LargeShipTable = DataDB.GetTable<LargeShip>();
            Table<LightShip> LightShipTable = DataDB.GetTable<LightShip>();
            Table<MediumShip> MediumShipTable = DataDB.GetTable<MediumShip>();
            Table<Product> ProductTable = DataDB.GetTable<Product>();


            var LargeShipQuery =
                from ship in LargeShipTable                
                select ship;

            int i = 0;
            foreach (LargeShip ship in LargeShipQuery)
            {
                Console.WriteLine("{0} \t{1} \t{2}", ship.Id, ship.Name, ship.Attack);
                ship.Name = $"LargeShip_{i}";
                ship.Attack = i;
                i++;
            }

            var LightShipQuery =
                from ship in LightShipTable
                select ship;

            i = 0;
            foreach (LightShip ship in LightShipQuery)
            {
                Console.WriteLine("{0} \t{1} \t{2}", ship.Id, ship.Name, ship.Attack);
                ship.Name = $"LargeShip_{i}";
                ship.Attack = i;
                i++;
            }

            var MediumShipQuery =
                from ship in MediumShipTable
                select ship;

            i = 0;
            foreach (MediumShip ship in MediumShipQuery)
            {
                Console.WriteLine("{0} \t{1} \t{2}", ship.Id, ship.Name, ship.Attack);

                ship.Name = $"MediumShip_{i}";
                ship.Attack = i;
                i++;
            }

            DataDB.SubmitChanges();

            LargeShip l1 = new LargeShip(1, 2, 3, 4, "LargeShip 1", "LargeShip.jpg", "LargeShip");

            DataDB.GetTable<LargeShip>().InsertOnSubmit(l1);
            DataDB.SubmitChanges();


        }


        public async static void CreateTableAsync( SqlConnection connection, string table)
        {

            try
            {
                //SqlCommand myCommand = new SqlCommand(str, connection);
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Подключение закрыто.");
                }

            }
        }


        private static Dictionary <string, EnumTypeAccount> _dUsers = new Dictionary<string, EnumTypeAccount> 
		{ 
		    ["admin"] = EnumTypeAccount.Admin, 
		    ["player"] =  EnumTypeAccount.Player, 
		    ["vip"] =  EnumTypeAccount.Vip, 
		    ["new"] = EnumTypeAccount.Player
		};
        private static int _crystalPrice = 100;
        private static Dictionary <string, EnumTypeAccount> _dItems = new Dictionary<string, EnumTypeAccount> 
		{ 
		    ["admin"] = EnumTypeAccount.Admin, 
		    ["player"] = EnumTypeAccount.Player, 
		    ["vip"] = EnumTypeAccount.Vip, 
		    ["new"] = EnumTypeAccount.Player
		};
        
        
        private static int _goldPrice = 50;
        private static List <ProductDB> _productMarketPlayer = new List<ProductDB>();
		private static Dictionary <int, CardDB> _dCards = new Dictionary<int, CardDB> ();
		private static List <ProductDB> _productMarketVip = new List<ProductDB>();
        private static int _money = 0;
        private static int _disscount = 0;

        

        static DB(){
                       

            ProductDB product1 = new ProductDB("Продукт1", 0, 5, 50);
			ProductDB product2 = new ProductDB("Продукт2", 0, 15, 500);
			ProductDB product3 = new ProductDB("Продукт2", 0, 3, 100);
			ProductDB product4 = new ProductDB("Продукт2", 0, 24, 150);
	
			_productMarketPlayer.Add(product1);
			_productMarketPlayer.Add(product2);
			_productMarketVip.Add(product3);
			_productMarketVip.Add(product4);
		}

		
        public static bool HasUser(string name, string pass)
        {
            return _dUsers.ContainsKey(name);
        }

      
        public static int GetId(string name)
        {

            return 0;
        }

       
        public static EnumTypeAccount GetTypeAccount(string name)
        {

            return _dUsers[name];
        }

       
        public static bool NewAccount(string name)
        {

            _dUsers.Add(name, EnumTypeAccount.Player);
            return _dUsers.ContainsKey(name);
        }

       
        public static CardDB GetCard(int id)
        {

            return _dCards[id];
        }

        public static List<ProductDB> GetProductsMarketPlayer(){

			return _productMarketPlayer;
		}

        public static int GoldPrice {
            get {
                return _crystalPrice;
            }
            set {
                _crystalPrice = value;
            }
        }

        public static List<ProductDB> GetProductsMarketVip(){

			return _productMarketVip;
		}

        public static int CrystalPrice {
            get {
                return _goldPrice;
            }
            set {
                _goldPrice = value;
            }
        }


        public static int GetMoney(int id)
        {

            return _money;
        }

       
        public static int GetDisscount(int id)
        {

            return _disscount;
        }

       
        public static void SetMoney(int id, int money)
        {

            _money += money;
        }

    }

}