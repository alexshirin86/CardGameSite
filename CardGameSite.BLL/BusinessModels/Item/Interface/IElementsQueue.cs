namespace Model.Item.Interface {
	public interface IElementsQueue<T> : IElements<T>  {

		/// <summary>
		/// <param name="item"></param>
		/// </summary>
		void Enqueue(T item);

		T Dequeue();

		T Peek();

		/// <summary>
		/// <param name="item"></param>
		/// </summary>
		bool TryPeek(out T item);

		// method ToArray is inherited from base class

		// method GetTypeContainer is inherited from base class

		// method Clear is inherited from base class

		// method CopyTo is inherited from base class

		// method Contains is inherited from base class

		// method GetEnumerator is inherited from base class


	}

}
