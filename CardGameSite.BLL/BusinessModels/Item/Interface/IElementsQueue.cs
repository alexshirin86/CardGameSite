namespace CardGameSite.BLL.BusinessModels.Item.Interface 
{
	public interface IElementsQueue<T> : IElements<T>
	{

		void Enqueue(T item);

		T Dequeue();

		T Peek();

		bool TryPeek(out T item);

		// method ToArray is inherited from base class

		// method GetTypeContainer is inherited from base class

		// method Clear is inherited from base class

		// method CopyTo is inherited from base class

		// method Contains is inherited from base class

		// method GetEnumerator is inherited from base class


	}

}
