using System;
using CardGameSite.BLL.BusinessModels.Item.Interface;

namespace CardGameSite.BLL.BusinessModels.PartyGame
{
	public class ContainerFixed<T> : IElementsListFixed<T>
	{
		public T This_ { get; set; }
		public int Count { get { return _container.Length; } }
		private T[] _container;

		public System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			yield return (T)_container.GetEnumerator();
		}

		public bool Contains(T item)
		{
			return Array.Exists(_container, element => element.Equals(item));
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
			Array.Clear(_container, 0, _container.Length);
		}
		public System.Type GetTypeContainer()
		{
			return _container.GetType();
		}
		public ContainerFixed(int count)
		{
			_container = new T[count];
		}
		public T[] ToArray()
		{
			return _container;
		}

		public bool Add(T item)
		{
			for (int i = 0; i < _container.Length; i++)
			{
				if (_container[i] == null)
				{
					_container[i] = item;
					return true;
				}
			}
			return false;
		}
	}
}
