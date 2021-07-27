///////////////////////////////////////////////////////////
//  ProductDB.cs
//  Implementation of the Class ProductDB
//  Created on:      31-май-2021 13:58:57
//  Original author: Aleksey Shirin
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Model {
	public struct ProductDB   {

		private int price;

		private string name;

		private int gold;

		private int crystal;

		/// 
		/// <param name="name"></param>
		/// <param name="gold"></param>
		/// <param name="crystal"></param>
		/// <param name="price"></param>
		public ProductDB(string name, int gold, int crystal, int price)
        {

			this.name = name;
			this.gold = gold;
			this.crystal = crystal;
			this.price = price;
		}

        public int Price {
            get {
                return price;
            }
        }

        public string Name {
            get {
                return name;
            }

        }

        public int Gold {
            get {
                return gold;
            }

        }

        public int Crystal {
            get {
                return crystal;
            }

        }

    }//end ProductDB

}//end namespace Model