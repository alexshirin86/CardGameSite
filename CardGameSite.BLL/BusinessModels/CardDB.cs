///////////////////////////////////////////////////////////
//  CardDB.cs
//  Implementation of the Class CardDB
//  Created on:      31-май-2021 13:58:57
//  Original author: Aleksey Shirin
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Model {
	/// <summary>
	/// Включено для текущей версии
	/// </summary>
	public struct CardDB   {

		private string name;

		private string flavour;

		private int crystal;

		private int gold;

		/// 
		/// <param name="name"></param>
		/// <param name="flavour"></param>
		/// <param name="gold"></param>
		/// <param name="crystal"></param>
		public CardDB(string name, string flavour, int gold, int crystal)
        {

			this.name = name;
			this.flavour = flavour;
			this.gold = gold;
			this.crystal = crystal;
	
		}

        public string Name {
            get {
                return name;
            }

        }

        public string Flavour {
            get {
                return flavour;
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

    }//end CardDB

}//end namespace Model