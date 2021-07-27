///////////////////////////////////////////////////////////
//  IMarket.cs
//  Implementation of the Interface IMarket
//  Created on:      07-θών-2021 13:17:52
//  Original author: Aleksey Shirin
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Model.Interfaces {
	public interface IMarket  {

		IAccount Account{
			get;			
		}

		void ShowProducts();
	}//end IMarket

}//end namespace Interfaces