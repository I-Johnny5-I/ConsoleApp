using System;
using System.Text;

namespace ConsoleApp.Lecture1
{
	class Lecture
	{
		public static void Run()
		{
			// Base Types
			int myInt = 5;
			double myDouble = 1.1861;
			string myString = "Hello, World!";
			bool myBool = true;
			
			long myLong = 319473L;

			// More Base Types
			byte myByte = 255; // 0..255
			sbyte mySByte = 127; // -128..127
			uint myUInt = 561U;
			ulong myULong = 1835186186181UL;
			short myShort = 16768;
			ushort myUShort = 146;
			float myFloat = 5.1874F;
			decimal myDecimal = 4532.235235235M;

			string output = $"{myInt} {myDouble} {myString} {myBool} {myLong}\n" + 
				$"{myByte} {mySByte} {myUInt} {myULong} {myShort} {myUShort} {myFloat} {myDecimal}";
			Console.WriteLine(output);
		}
	}
}