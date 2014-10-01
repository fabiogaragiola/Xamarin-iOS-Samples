using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Sample
{
	public class Data
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Selected { get; set; }

		public Data()
		{
		}
	}

	public class Model
	{
		List<Data> _model = new List<Data> ();

		public Data this[int index]
		{
			get { return _model [index]; }
			set { _model [index] = value; }
		}

		public int Count
		{
			get { return  _model.Count; }
		}

		public void Add(Data item)
		{
			_model.Add (item);
		}

		public void ResetSelected()
		{
			var index = _model.FindIndex (y => y.Selected);

			if (index > -1)
				_model [index].Selected = false;
		}

		static byte[] RandomBytes(int length)
		{
			var random = new RNGCryptoServiceProvider();
			var b = new byte[length];
			random.GetBytes(b);
			return b;
		}

		// Generate a string of random characters
		static string RandomWord(int length)
		{
			const string chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

			var stringChars = new char[length];
			var b = RandomBytes(length);

			for (int i = 0; i < length; i++)
			{
				var j = b[i] / 10;
				if (i == 0)
					j = j + 26;
				stringChars[i] = chars[j];
			}

			return new string(stringChars);
		}

		// Initialize the Model
		public static Model Init(int numberOfItems = 100)
		{
			var model = new Model();

			for (int i = 0; i < numberOfItems; i++)
			{
				model.Add(new Data
					{
						Name = String.Format ("{0} {1}", RandomWord(8), RandomWord(12)),
						Description = RandomWord(12),
						Selected = false
					});
			}

			return model;
		}

		//		public static Model Init()
		//		{
		//			const string filename = "YourFileHere!";
		//
		//			var model = new Model();
		//
		//			if (File.Exists(filename))
		//			{
		//				foreach (string line in File.ReadLines(filename))
		//				{
		//					model.Add(new Data
		//						{
		//							Name = line.Split(',')[0],
		//							Description = line.Split(',')[1],
		//							Selected = false
		//						});
		//				}
		//			}
		//
		//			return model;
		//		}
	}
}

