namespace CardGameSite.BLL.BusinessModels.Item.Interface
{
	public interface IElementsStack<T> : IElements<T> 
	{
		T Pop();
		void Push(T item);
		T Peek();
		bool TryPeek(out T result);
		bool TryPop(out T result);

	}

}
