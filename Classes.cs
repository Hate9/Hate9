using System;
using System.Collections.Generic;
using System.Text;

namespace Hate9
{
	/// <summary>A representation of a List, with a point representing the active entry.</summary>
	public class ListP<T> : List<T>
	{
		public delegate void EventHandler(byte point);
		public event EventHandler OnPointChanged;
		private int _point = 0;
		/// <summary>Represents the active entry point</summary>
		public int point
		{
			get { return _point; }
			set
			{
				_point = value;
				if (point >= 0)
				{
					OnPointChanged?.Invoke((byte)_point);
				}
			}
		}

		public T GetValueAtPoint()
		{
			return this[point];
		}

		new public int Add(T item)
		{
			base.Add(item);
			return Count;
		}
	}
}
