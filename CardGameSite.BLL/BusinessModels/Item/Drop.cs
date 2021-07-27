using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Item.Interface;

namespace CardGameSite.BLL.BusinessModels.Item
{
	public class Drop<T> : Element , IElementsStack<T>
	{
		private Stack<T> _container;

		public override string Name { get; set; }
		public override string ImagePath { get; }
		public override int Id { get; }
		public int Count { get { return _container.Count; } }

		public T Pop()
		{
			try
			{
				return _container.Pop();
			}	
			catch (InvalidOperationException e)
			{
				return default(T);
			}
		}

		public void Push(T item)
		{
			_container.Push(item);
		}

		public T Peek() 
		{
			try
			{
				return _container.Peek();
			}	
			catch (InvalidOperationException e)
			{
				return default(T);
			}
		}
		
		public bool TryPeek(out T result)
		{
			return _container.TryPeek(out result);
		}
		
		public bool TryPop(out T result) 
		{
			return _container.TryPop(out result);
		}
		
		public System.Collections.Generic.IEnumerator<T> GetEnumerator() {
			return _container.GetEnumerator();
		}
		
		public bool Contains(T item)
		{
			return _container.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			try
			{
				_container.CopyTo(array, arrayIndex);
			}
			catch (ArgumentOutOfRangeException e)
			{
			}
			catch (ArgumentNullException e)
			{
			}
			catch (ArgumentException e)
			{
			}
			catch (ArrayTypeMismatchException e)
			{
			}
		}

		public void Clear()
		{
			_container.Clear();
		}

		public System.Type GetTypeContainer()
		{
			return _container.GetType();
		}

		public T[] ToArray()
		{
			return _container.ToArray();
		}

	}

}
