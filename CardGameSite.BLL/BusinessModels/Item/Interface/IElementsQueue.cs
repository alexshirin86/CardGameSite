namespace CardGameSite.BLL.BusinessModels.Item.Interface 
{
	public interface IElementsQueue<T> : IElements<T>
	{

		void Enqueue(T item);

		T Dequeue();

		T Peek();

		bool TryPeek(out T item);
				
	}

}
