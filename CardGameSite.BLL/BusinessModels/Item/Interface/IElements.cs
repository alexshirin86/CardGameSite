using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace CardGameSite.BLL.BusinessModels.Item.Interface
{
	public interface IElements<T>
	{
		int Count { get; }

		IEnumerator<T> GetEnumerator();

		bool Contains(T item);

		void CopyTo(T[] array, [Optional, DefaultParameterValueAttribute(0)]int arrayIndex);
		
		void Clear();
		
		Type GetTypeContainer();
		T[] ToArray();

	}

}
