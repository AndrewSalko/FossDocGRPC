using System;
using System.Collections.Generic;
using System.Text;

namespace Foss.FossDoc.Standard
{
	public struct OID
	{
		public int _base;

		public int Data1;
		public short Data2;
		public short Data3;
		public byte Data40;
		public byte Data41;
		public byte Data42;
		public byte Data43;
		public byte Data44;
		public byte Data45;
		public byte Data46;
		public byte Data47;


		/// <summary>
		/// Пустой объектный идентификатор.
		/// </summary>
		public static readonly OID Empty = new OID();

		/// <summary>
		/// Не определенный
		/// </summary>
		public static readonly OID Unspecified;


		private const int MapSize = 'F' + 1;
		private static readonly byte[] Map = new byte[MapSize];
		private static readonly byte[] MapX16 = new byte[MapSize];

		private const int IMapSize = byte.MaxValue + 1;
		private static readonly char[] IMap1 = new char[IMapSize];
		private static readonly char[] IMap2 = new char[IMapSize];

		[Serializable]
		public class EqualityComparer : IEqualityComparer<OID>
		{
			#region IEqualityComparer<OID> Members

			/// <summary>
			/// Сравнение двух идентификаторов объектов.
			/// </summary>
			/// <param name="x">Первый идентификатор объекта для сравнения.</param>
			/// <param name="y">Второй идентификатор объекта для сравнения.</param>
			/// <returns>
			/// <para>Логический <see cref="bool"/> результат сравнения идентификаторов объектов.</para>
			/// <para>Если идентификаторы равны, функция возвращает 'true'; иначе - 'false'.</para>
			/// </returns>
			public bool Equals(OID x, OID y)
			{
				return OID.Equals(x, y);
			}

			/// <summary>
			/// Получение 'HashCode' для идентификатора объекта.
			/// </summary>
			/// <param name="obj">Идентификатор объекта, 'HashCode' которого необходимо получить.</param>
			/// <returns>'HashCode' для указанного идентификатора объекта.</returns>
			public int GetHashCode(OID obj)
			{
				return obj.GetHashCode();
			}

			#endregion

			/// <summary>
			///Инструмент для сравнения идентификаторов объектов. 
			/// </summary>
			public static readonly EqualityComparer Instance = new EqualityComparer();
		}

		static int _GetHashCode(OID obj)
		{
			return obj._base ^
				(int)obj.Data2 ^
				obj.Data40 ^
				obj.Data42 ^
				obj.Data44 ^
				obj.Data46;
		}

		public static bool operator == (OID obj1, OID obj2)
		{
			return OID.Equals(obj1, obj2);
		}

		public static bool operator != (OID obj1, OID obj2)
		{
			return !OID.Equals(obj1, obj2);
		}

		public static bool IsEmpty(OID oid)
		{
			return Equals(oid, Empty);
		}

		public static bool IsUnspecified(OID oid)
		{
			return Equals(oid, Unspecified);
		}

		public static bool IsEmptyOrUnspecified(OID oid)
		{
			return Equals(oid, Empty) || Equals(oid, Unspecified);
		}

		public override bool Equals(object obj)
		{
			return OID.Equals(this, (OID)obj);
		}

		public override int GetHashCode()
		{
			return _GetHashCode(this);
		}

		public static bool Equals(OID oid1, OID oid2)
		{
			return
				oid1.Data1 == oid2.Data1 &&
				oid1.Data2 == oid2.Data2 &&
				oid1.Data3 == oid2.Data3 &&
				oid1.Data40 == oid2.Data40 &&
				oid1.Data41 == oid2.Data41 &&
				oid1.Data42 == oid2.Data42 &&
				oid1.Data43 == oid2.Data43 &&
				oid1.Data44 == oid2.Data44 &&
				oid1.Data45 == oid2.Data45 &&
				oid1.Data46 == oid2.Data46 &&
				oid1.Data47 == oid2.Data47 &&
				oid1._base == oid2._base;
		}


		static OID()
		{
			Unspecified._base = -1;
			Unspecified.Data1 = -1;
			Unspecified.Data2 = -1;
			Unspecified.Data3 = -1;
			Unspecified.Data40 = 0xff;
			Unspecified.Data41 = 0xff;
			Unspecified.Data42 = 0xff;
			Unspecified.Data43 = 0xff;
			Unspecified.Data44 = 0xff;
			Unspecified.Data45 = 0xff;
			Unspecified.Data46 = 0xff;
			Unspecified.Data47 = 0xff;

			for (byte i = 0; i < 16; i++)
			{
				char c = i.ToString("X")[0];
				MapX16[c] = (byte)((Map[c] = i) * 16);
			}
			for (int i = byte.MinValue; i < IMapSize; i++)
			{
				string s = i.ToString("X2");
				IMap1[i] = s[0];
				IMap2[i] = s[1];
			}
		}

		//static public OID NewOID()
		//{
		//	Guid guid = Guid.NewGuid();
		//	return OID.FromGuid(guid.GetHashCode(), guid);
		//}

		///// <summary>
		///// Создание нового идентификатора объекта по заданному базовому номеру.
		///// </summary>
		///// <param name="baseNumber">Базовый номер идентификатора.</param>
		///// <returns>Новый идентификатор объекта с заданной базой.</returns>
		///// <remarks>Базовый номер идентификатора позволяет классифицировать, например,
		///// идентификаторы объектов по отношению их к каким-либо классам объектов.</remarks>
		//static public DS.OID NewOID(int baseNumber)
		//{
		//	return OID.FromGuid(baseNumber, Guid.NewGuid());
		//}

		static private OID FromChars(char[] str)
		{
			byte[] Bytes = new byte[20];
			Bytes[0] = (byte)(Map[str[25]] | MapX16[str[24]]);
			Bytes[1] = (byte)(Map[str[27]] | MapX16[str[26]]);
			Bytes[2] = (byte)(Map[str[29]] | MapX16[str[28]]);
			Bytes[3] = (byte)(Map[str[31]] | MapX16[str[30]]);
			Bytes[4] = (byte)(Map[str[33]] | MapX16[str[32]]);
			Bytes[5] = (byte)(Map[str[35]] | MapX16[str[34]]);
			Bytes[6] = (byte)(Map[str[37]] | MapX16[str[36]]);
			Bytes[7] = (byte)(Map[str[39]] | MapX16[str[38]]);
			Bytes[8] = (byte)(Map[str[23]] | MapX16[str[22]]);
			Bytes[9] = (byte)(Map[str[21]] | MapX16[str[20]]);
			Bytes[10] = (byte)(Map[str[19]] | MapX16[str[18]]);
			Bytes[11] = (byte)(Map[str[17]] | MapX16[str[16]]);
			Bytes[12] = (byte)(Map[str[15]] | MapX16[str[14]]);
			Bytes[13] = (byte)(Map[str[13]] | MapX16[str[12]]);
			Bytes[14] = (byte)(Map[str[11]] | MapX16[str[10]]);
			Bytes[15] = (byte)(Map[str[9]] | MapX16[str[8]]);
			Bytes[16] = (byte)(Map[str[7]] | MapX16[str[6]]);
			Bytes[17] = (byte)(Map[str[5]] | MapX16[str[4]]);
			Bytes[18] = (byte)(Map[str[3]] | MapX16[str[2]]);
			Bytes[19] = (byte)(Map[str[1]] | MapX16[str[0]]);
			OID OID = new OID();
			OID._base = BitConverter.ToInt32(Bytes, 16);
			OID.Data1 = BitConverter.ToInt32(Bytes, 12);
			OID.Data2 = BitConverter.ToInt16(Bytes, 10);
			OID.Data3 = BitConverter.ToInt16(Bytes, 8);
			OID.Data40 = Bytes[0];
			OID.Data41 = Bytes[1];
			OID.Data42 = Bytes[2];
			OID.Data43 = Bytes[3];
			OID.Data44 = Bytes[4];
			OID.Data45 = Bytes[5];
			OID.Data46 = Bytes[6];
			OID.Data47 = Bytes[7];
			return OID;
		}

		/// <summary>
		/// Преобразование идентификаторов объектов в массив символов.
		/// </summary>
		/// <param name="OID">Идентификатор объекта.</param>
		/// <returns>Массив символов. Представляет собой символьное представление идентификатора объекта.</returns>
		static public char[] ToCharArray(OID OID)
		{
			char[] s = new char[40];
			byte[] Bytes = BitConverter.GetBytes(OID._base);
			byte b = Bytes[3];
			s[0] = IMap1[b];
			s[1] = IMap2[b];
			b = Bytes[2];
			s[2] = IMap1[b];
			s[3] = IMap2[b];
			b = Bytes[1];
			s[4] = IMap1[b];
			s[5] = IMap2[b];
			b = Bytes[0];
			s[6] = IMap1[b];
			s[7] = IMap2[b];
			Bytes = BitConverter.GetBytes(OID.Data1);
			b = Bytes[3];
			s[8] = IMap1[b];
			s[9] = IMap2[b];
			b = Bytes[2];
			s[10] = IMap1[b];
			s[11] = IMap2[b];
			b = Bytes[1];
			s[12] = IMap1[b];
			s[13] = IMap2[b];
			b = Bytes[0];
			s[14] = IMap1[b];
			s[15] = IMap2[b];
			Bytes = BitConverter.GetBytes(OID.Data2);
			b = Bytes[1];
			s[16] = IMap1[b];
			s[17] = IMap2[b];
			b = Bytes[0];
			s[18] = IMap1[b];
			s[19] = IMap2[b];
			Bytes = BitConverter.GetBytes(OID.Data3);
			b = Bytes[1];
			s[20] = IMap1[b];
			s[21] = IMap2[b];
			b = Bytes[0];
			s[22] = IMap1[b];
			s[23] = IMap2[b];

			b = OID.Data40;
			s[24] = IMap1[b];
			s[25] = IMap2[b];
			b = OID.Data41;
			s[26] = IMap1[b];
			s[27] = IMap2[b];
			b = OID.Data42;
			s[28] = IMap1[b];
			s[29] = IMap2[b];
			b = OID.Data43;
			s[30] = IMap1[b];
			s[31] = IMap2[b];
			b = OID.Data44;
			s[32] = IMap1[b];
			s[33] = IMap2[b];
			b = OID.Data45;
			s[34] = IMap1[b];
			s[35] = IMap2[b];
			b = OID.Data46;
			s[36] = IMap1[b];
			s[37] = IMap2[b];
			b = OID.Data47;
			s[38] = IMap1[b];
			s[39] = IMap2[b];
			return s;
		}

		static public string ToString(OID OID)
		{
			return new string(ToCharArray(OID));
		}

		public override string ToString()
		{
			return ToString(this);
		}

		/// <summary>
		/// Получение идентификатора объекта по его строковому представлению.
		/// </summary>
		/// <param name="s">Строковое представление идентификатора объекта.</param>
		/// <returns>Идентификатор объекта.</returns>
		static public OID FromString(string s)
		{
			return FromChars(s.ToCharArray());
		}

		public byte[] ToByteArray()
		{
			return new byte[]
			{
				(byte)_base,
				(byte)(_base >> 8),
				(byte)(_base >> 16),
				(byte)(_base >> 24),
				(byte)(Data1),
				(byte)(Data1 >> 8),
				(byte)(Data1 >> 16),
				(byte)(Data1 >> 24),
				(byte)(Data2),
				(byte)(Data2 >> 8),
				(byte)(Data3),
				(byte)(Data3 >> 8),
				Data40,
				Data41,
				Data42,
				Data43,
				Data44,
				Data45,
				Data46,
				Data47
			};
		}

		public static OID FromByteArray(byte[] oidBlock)
		{
			if (oidBlock == null)
				throw new ArgumentNullException("oidBlock");
			if (oidBlock.Length != 20)
				throw new ArgumentNullException("oidBlock");

			OID result = new OID();

			result._base = BitConverter.ToInt32(oidBlock, 0);//0 1 2 3
			result.Data1 = BitConverter.ToInt32(oidBlock, 4);//4 5 6 7
			result.Data2 = BitConverter.ToInt16(oidBlock, 8);//8 9
			result.Data3 = BitConverter.ToInt16(oidBlock, 10);//10 11

			//8 bytes
			result.Data40 = oidBlock[12];
			result.Data41 = oidBlock[13];
			result.Data42 = oidBlock[14];
			result.Data43 = oidBlock[15];
			result.Data44 = oidBlock[16];
			result.Data45 = oidBlock[17];
			result.Data46 = oidBlock[18];
			result.Data47 = oidBlock[19];

			return result;
		}

	}
}
