using System;
using System.Collections.Generic;
using CardGameSite.BLL.BusinessModels.Item.Interface;

namespace CardGameSite.BLL.BusinessModels.Item
{
	public class Drop<T> : Element , IElementsStack<T>
	{
		private readonly Stack<T> _container;
		public override int Id { get; protected set; }
		public override string Name { get; protected set; }
		public override string Description { get; protected set; }
		public int Count { get { return _container.Count; } }

		public Drop(int id, string name, string description) :	base(id, name, description)
		{
			_container = new Stack<T>();
		}

		public Drop()
		{
			_container = new Stack<T>();
		}

		public T Pop()
		{
			try
			{
				return _container.Pop();
			}	
			catch (InvalidOperationException)
			{
				return default;
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
			catch (InvalidOperationException)
			{
				return default;
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
		
		public IEnumerator<T> GetEnumerator() {
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

		public void Clear()
		{
			_container.Clear();
		}

		public Type GetTypeContainer()
		{
			return _container.GetType();
		}

		public T[] ToArray()
		{
			return _container.ToArray();
		}

	}

}
