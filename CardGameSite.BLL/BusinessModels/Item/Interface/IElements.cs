using System;
using System.Runtime.InteropServices;

namespace CardGameSite.BLL.BusinessModels.Item.Interface
{
	public interface IElements<T>
	{
		int Count { get; }

		System.Collections.Generic.IEnumerator<T> GetEnumerator();

		bool Contains(T item);

		void CopyTo(T[] array, [Optional, DefaultParameterValueAttribute(0)]int arrayIndex);
		
		void Clear();
		
		System.Type GetTypeContainer();
		T[] ToArray();

	}

}
