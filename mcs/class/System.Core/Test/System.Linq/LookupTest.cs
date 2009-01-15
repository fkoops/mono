﻿//
// EnumerableTest.cs
//
// Author:
//   Jb Evain (jbevain@novell.com)
//
// (C) 2009 Novell, Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace MonoTests.System.Linq {

	[TestFixture]
	public class LookupTest {

		class Color {

			public string Name { get; set; }
			public int Value { get; set; }

			public Color (string name, int value)
			{
				Name = name;
				Value = value;
			}
		}

		static IEnumerable<Color> GetColors ()
		{
			yield return new Color ("Red", 0xff0000);
			yield return new Color ("Green", 0x00ff00);
			yield return new Color ("Blue", 0x0000ff);
		}

		[Test]
		[Category ("NotWorking")]
		public void LookupIgnoreCase ()
		{
			var lookup = GetColors ().ToLookup (
				c => c.Name,
				c => c.Value,
				StringComparer.OrdinalIgnoreCase);

			Assert.AreEqual (0xff0000, lookup ["red"].First ());
			Assert.AreEqual (0x00ff00, lookup ["GrEeN"].First ());
			Assert.AreEqual (0x0000ff, lookup ["Blue"].First ());
		}
	}
}
