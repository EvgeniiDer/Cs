﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Human
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public uint Age { get; set; }
		public Human(string lastName, string firstName, uint age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"HConstructor:\t{GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"HCopyConstructor:\t{GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"HDestructor:\t{GetHashCode()}");
		}

		public void Print()
		{
			Console.WriteLine($"{LastName} {FirstName} {Age}");
		}
		public override string ToString()
		{
			return (base.ToString().Split('.').Last()+":").PadRight(12)+$"{LastName.PadRight(10)}{FirstName.PadRight(10)}{Age.ToString().PadRight(5)}";
		}
		public virtual string ToFileString()
		{
			return $"{base.ToString().Split('.').Last()},{LastName},{FirstName},{Age}";
		}
		public virtual void Init(string[] values)
		{
			LastName = values[1];
			FirstName = values[2];
			Age = Convert.ToUInt32(values[3]);
		}
	}
}