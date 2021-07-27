using System;

namespace Model.Item.Interface {
	public interface IElementsList<T> : IElementsListFixed<T>  {

		void Add(T item);

		bool Remove(T item);

		void Insert(int index, T item);

	}

}
