using System;
using System.Collections.Generic;
using Model.Item.Interface;

namespace Model.PartyGame {
	public class Container<T> : IElementsList<T>  {
		private List<T> _container;
		public T This_ { get; set; }
		public int Count { get { return _container.Count; } }

		public void Add(T item) {
			_container.Add(item);
		}
		public bool Remove(T item) {
			return _container.Remove(item);
		}
		public void Insert(int index, T item) {
			try
			{
				_container[index] = item;
			}
			catch (IndexOutOfRangeException e)
			{
			}
		}
		public T[] ToArray() {
			return _container.ToArray();
		}
		public Container() {
			_container = new List<T>();
		}
		public Container(int count) {
			_container = new List<T>(count);
		}
		public void Clear() {
			_container.Clear();
		}
		public bool Contains(T item) {
			return _container.Contains(item);
		}
		public IEnumerator<T> GetEnumerator() {
			return _container.GetEnumerator();
		}

		public void CopyTo(T[] array, int arrayIndex = 0) {
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
		public System.Type GetTypeContainer() {
			return _container.GetType();
		}

	}

}
