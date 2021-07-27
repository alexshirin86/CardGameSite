using System;

namespace CardGameSite.BLL.BusinessModels.Item.Interface 
{
	public interface IElementsList<T> : IElementsListFixed<T> 
	{

		void Add(T item);

		bool Remove(T item);

		void Insert(int index, T item);

	}

}
