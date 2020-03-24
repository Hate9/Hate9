using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Hate9
{
    public class Methods
    {
		public static byte BoolsToByte(bool bool1 = false, bool bool2 = false, bool bool3 = false, bool bool4 = false, bool bool5 = false, bool bool6 = false, bool bool7 = false, bool bool8 = false)
		{
			bool[] bools = new bool[] { bool1, bool2, bool3, bool4, bool5, bool6, bool7, bool8 };

			return BoolsToByte(bools)[0];
		}

		public static byte[] BoolsToByte(params bool[] bools)
		{
			List<byte> result = new List<byte>();

			int index = 1;
			for (int i = 0; i < bools.Length; i++)
			{
				if (i >= 8 * index)
				{
					index++;
				}
				if (result.Count < index)
				{
					result.Add(0);
				}

				if (bools[i])
				{
					result[index - 1] |= (byte)(1 << (i % (index * 8)));
				}
			}
			return result.ToArray();
		}
	}



	public static class Extensions
	{
		/// <summary>
		/// Creates a <see cref="ListP{T}"/> from an <see cref="IEnumerable{T}"/>.
		/// </summary>
		public static ListP<T> ToListP<T>(this T[] values)
		{
			List<T> temp = values.ToList();
			ListP<T> temp2 = new ListP<T>();
			temp2.AddRange(temp);
			return temp2;
		}

		public static bool IsNegative(this Point point)
		{
			return point.X < 0 || point.Y < 0;
		}

		public static void Set(this ref bool b)
		{
			b = true;
		}

		public static void Unset(this ref bool b)
		{
			b = false;
		}

		public static void Invert(this ref bool b)
		{
			b = !b;
		}

		public static T DeepClone<T>(this T obj)
		{
			using (var ms = new System.IO.MemoryStream())
			{
				var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				formatter.Serialize(ms, obj);
				ms.Position = 0;

				return (T)formatter.Deserialize(ms);
			}
		}

		public static bool[] ToBools(this byte input)
		{
			/*
			bool[] result = new bool[8];
			for (int i = 0; i < 8; i++)
			{
				result[i] = (input & (1 << i)) == 0 ? false : true;
			}
			return result;
			*/

			List<bool> result = new List<bool>();
			for (int i = 0; i < 8; i++)
			{
				result.Add((input & (1 << i)) == 0 ? false : true);
			}
			while (true)
			{
				if (result[result.Count - 1])
				{
					break;
				}
				else
				{
					result.RemoveAt(result.Count - 1);
				}
			}
			return result.ToArray();
		}
	}
}
