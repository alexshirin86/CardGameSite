using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Item.Interface;
using System.Linq;

namespace CardGameSite.BLL.BusinessModels.Item
{
	public class Deck<T> : Element , IElementsQueue<T> 
	{
		private readonly Queue<T> _container;
		public override int Id { get; protected set; }
		public override string Name { get; protected set; }
		public override string Description { get; protected set; }
		public int Count { get { return _container.Count; } }


		public void Enqueue(T item) 
		{
			_container.Enqueue(item);
		}

		public IEnumerator<T> GetEnumerator() 
		{
			return _container.GetEnumerator();
		}

		public bool Contains(T item) {
			return _container.Contains(item);
		}

		public T Dequeue()
		{
            try
            {
				return _container.Dequeue();
			}
			catch (InvalidOperationException)
            {
				return default;
            }			
		}

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			try
			{
				_container.CopyTo(array, arrayIndex);
			}
			catch (ArgumentOutOfRangeException)
			{
			}
			catch (ArgumentNullException)
			{
			}
			catch (ArgumentException)
			{
			}
			catch (ArrayTypeMismatchException)
            {
			}

		}

		public T Peek() 
		{
			try
			{
				return _container.Peek();
			}	
			catch (InvalidOperationException)
            {
				return default;
			}
		}
		public void Clear() => _container.Clear();

		public bool TryPeek(out T item) 
		{
			return _container.TryPeek(out item);
		}

		public Type GetTypeContainer() {
			return _container.GetType();
		}

		public T[] ToArray()
		{
			return _container.ToArray();
		}

		public Deck(T[] arrayItems)
		{
			Random rand = new Random();
			T[] newArrayItems = arrayItems.OrderBy(x => rand.Next()).ToArray();
				
			_container = new Queue<T>();
				
			foreach ( T item in arrayItems)
			{
				_container.Enqueue(item);
			}
		}

		public Deck(int id)
		{
			/*arrayItems
			Random rand = new Random();
			T[] newArrayItems = arrayItems.OrderBy(x => rand.Next()).ToArray();

			_container = new Queue<T>();

			foreach (T item in arrayItems)
			{
				_container.Enqueue(item);
			}*/
		}

	}

}
