﻿namespace Corlib.NStar.Tests;

[TestClass]
public class RedStarLinqTests
{
	[TestMethod]
	public void TestAll()
	{
		G.IEnumerable<string> a = new List<string>(list);
		var b = E.ToArray(a);
		var c = a.All(x => x.Length > 0);
		var d = E.All(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("#"));
		d = E.All(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("M"));
		d = E.All(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, bool>)null!));
		a = list.ToArray();
		c = a.All(x => x.Length > 0);
		d = E.All(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("#"));
		d = E.All(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("M"));
		d = E.All(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, bool>)null!));
		a = enumerable;
		c = a.All(x => x.Length > 0);
		d = E.All(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("#"));
		d = E.All(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("M"));
		d = E.All(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, bool>)null!));
		a = enumerable2;
		c = a.All(x => x.Length > 0);
		d = E.All(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("#"));
		d = E.All(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("M"));
		d = E.All(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, bool>)null!));
		a = E.SkipWhile(list, _ => random.Next(10) != -1);
		c = a.All(x => x.Length > 0);
		d = E.All(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("#"));
		d = E.All(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.All(x => x.StartsWith("M"));
		d = E.All(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, bool>)null!));
		a = new List<string>(list);
		c = a.All((x, index) => x.Length > 0 && index >= 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => index < 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => x.StartsWith("M") && index > 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, int, bool>)null!));
		a = list.ToArray();
		c = a.All((x, index) => x.Length > 0 && index >= 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => index < 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => x.StartsWith("M") && index > 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, int, bool>)null!));
		a = enumerable;
		c = a.All((x, index) => x.Length > 0 && index >= 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => index < 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => x.StartsWith("M") && index > 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, int, bool>)null!));
		a = enumerable2;
		c = a.All((x, index) => x.Length > 0 && index >= 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => index < 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => x.StartsWith("M") && index > 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, int, bool>)null!));
		a = E.SkipWhile(list, _ => random.Next(10) != -1);
		c = a.All((x, index) => x.Length > 0 && index >= 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => index < 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.All((x, index) => x.StartsWith("M") && index > 0);
		d = E.All(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.All((Func<string, int, bool>)null!));
	}

	[TestMethod]
	public void TestAny()
	{
		G.IEnumerable<string> a = new List<string>(list);
		var b = E.ToArray(a);
		var c = a.Any(x => x.Length > 0);
		var d = E.Any(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("#"));
		d = E.Any(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("M"));
		d = E.Any(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, bool>)null!));
		a = list.ToArray();
		c = a.Any(x => x.Length > 0);
		d = E.Any(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("#"));
		d = E.Any(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("M"));
		d = E.Any(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, bool>)null!));
		a = enumerable;
		c = a.Any(x => x.Length > 0);
		d = E.Any(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("#"));
		d = E.Any(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("M"));
		d = E.Any(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, bool>)null!));
		a = enumerable2;
		c = a.Any(x => x.Length > 0);
		d = E.Any(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("#"));
		d = E.Any(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("M"));
		d = E.Any(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, bool>)null!));
		a = E.SkipWhile(list, _ => random.Next(10) != -1);
		c = a.Any(x => x.Length > 0);
		d = E.Any(a, x => x.Length > 0);
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("#"));
		d = E.Any(a, x => x.StartsWith("#"));
		Assert.AreEqual(c, d);
		c = a.Any(x => x.StartsWith("M"));
		d = E.Any(a, x => x.StartsWith("M"));
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, bool>)null!));
		a = new List<string>(list);
		c = a.Any((x, index) => x.Length > 0 && index >= 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => index < 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => x.StartsWith("M") && index > 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, int, bool>)null!));
		a = list.ToArray();
		c = a.Any((x, index) => x.Length > 0 && index >= 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => index < 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => x.StartsWith("M") && index > 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, int, bool>)null!));
		a = enumerable;
		c = a.Any((x, index) => x.Length > 0 && index >= 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => index < 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => x.StartsWith("M") && index > 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, int, bool>)null!));
		a = enumerable2;
		c = a.Any((x, index) => x.Length > 0 && index >= 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => index < 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => x.StartsWith("M") && index > 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, int, bool>)null!));
		a = E.SkipWhile(list, _ => random.Next(10) != -1);
		c = a.Any((x, index) => x.Length > 0 && index >= 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.Length > 0 && x.index >= 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => index < 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.index < 0);
		Assert.AreEqual(c, d);
		c = a.Any((x, index) => x.StartsWith("M") && index > 0);
		d = E.Any(E.Select(a, (elem, index) => (elem, index)), x => x.elem.StartsWith("M") && x.index > 0);
		Assert.AreEqual(c, d);
		Assert.ThrowsException<ArgumentNullException>(() => a.Any((Func<string, int, bool>)null!));
		a = new List<string>(list);
		c = a.Any();
		d = E.Any(a);
		Assert.AreEqual(c, d);
		a = list.ToArray();
		c = a.Any();
		d = E.Any(a);
		Assert.AreEqual(c, d);
		a = enumerable;
		c = a.Any();
		d = E.Any(a);
		Assert.AreEqual(c, d);
		a = enumerable2;
		c = a.Any();
		d = E.Any(a);
		Assert.AreEqual(c, d);
		a = E.SkipWhile(list, _ => random.Next(10) != -1);
		c = a.Any();
		d = E.Any(a);
		Assert.AreEqual(c, d);
	}

	[TestMethod]
	public void TestSetAll()
	{
		var a = E.ToArray(list).SetAll(defaultString);
		var b = new G.List<string>(list);
		for (int i = 0; i < b.Count; i++)
			b[i] = defaultString;
		Assert.IsTrue(RedStarLinq.Equals(a, b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = E.ToArray(list).SetAll(defaultString, 3);
		b = new G.List<string>(list);
		for (int i = 3; i < b.Count; i++)
			b[i] = defaultString;
		Assert.IsTrue(RedStarLinq.Equals(a, b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = E.ToArray(list).SetAll(defaultString, 2, 4);
		b = new G.List<string>(list);
		for (int i = 2; i < 6; i++)
			b[i] = defaultString;
		Assert.IsTrue(RedStarLinq.Equals(a, b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = E.ToArray(list).SetAll(defaultString, ^5);
		b = new G.List<string>(list);
		for (int i = b.Count - 5; i < b.Count; i++)
			b[i] = defaultString;
		Assert.IsTrue(RedStarLinq.Equals(a, b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = E.ToArray(list).SetAll(defaultString, ^6..4);
		b = new G.List<string>(list);
		for (int i = b.Count - 6; i < 4; i++)
			b[i] = defaultString;
		Assert.IsTrue(RedStarLinq.Equals(a, b));
		Assert.IsTrue(E.SequenceEqual(b, a));
	}

	[TestMethod]
	public void TestSkip()
	{
		var a = list.Skip(3);
		var b = E.Skip(list, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Skip(1000);
		b = E.Skip(list, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Skip(-2);
		b = E.Skip(list, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Skip(3);
		b = E.Skip(enumerable, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Skip(1000);
		b = E.Skip(enumerable, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Skip(-2);
		b = E.Skip(enumerable, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Skip(3);
		b = E.Skip(enumerable2, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Skip(1000);
		b = E.Skip(enumerable2, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Skip(-2);
		b = E.Skip(enumerable2, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
	}

	[TestMethod]
	public void TestSkipLast()
	{
		var a = list.SkipLast(4);
		var b = E.SkipLast(list, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.SkipLast(1000);
		b = E.SkipLast(list, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.SkipLast(-5);
		b = E.SkipLast(list, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.SkipLast(4);
		b = E.SkipLast(enumerable, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.SkipLast(1000);
		b = E.SkipLast(enumerable, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.SkipLast(-5);
		b = E.SkipLast(enumerable, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.SkipLast(4);
		b = E.SkipLast(enumerable2, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.SkipLast(1000);
		b = E.SkipLast(enumerable2, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.SkipLast(-5);
		b = E.SkipLast(enumerable2, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
	}

	[TestMethod]
	public void TestTake()
	{
		var a = list.Take(3);
		var b = E.Take(list, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(1000);
		b = E.Take(list, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(-2);
		b = E.Take(list, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(2..5);
		b = E.Take(list, 2..5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(5..2);
		b = E.Take(list, 5..2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(2..^3);
		b = E.Take(list, 2..^3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(5..^4);
		b = E.Take(list, 5..^4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(^5..6);
		b = E.Take(list, ^5..6);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(^10..9);
		b = E.Take(list, ^10..9);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.Take(^5..^2);
		b = E.Take(list, ^5..^2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(3);
		b = E.Take(enumerable, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(1000);
		b = E.Take(enumerable, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(-2);
		b = E.Take(enumerable, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(2..5);
		b = E.Take(enumerable, 2..5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(5..2);
		b = E.Take(enumerable, 5..2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(2..^3);
		b = E.Take(enumerable, 2..^3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(5..^4);
		b = E.Take(enumerable, 5..^4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(^5..6);
		b = E.Take(enumerable, ^5..6);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(^10..9);
		b = E.Take(enumerable, ^10..9);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.Take(^5..^2);
		b = E.Take(enumerable, ^5..^2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(3);
		b = E.Take(enumerable2, 3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(1000);
		b = E.Take(enumerable2, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(-2);
		b = E.Take(enumerable2, -2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(2..5);
		b = E.Take(enumerable2, 2..5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(5..2);
		b = E.Take(enumerable2, 5..2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(2..^3);
		b = E.Take(enumerable2, 2..^3);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(5..^4);
		b = E.Take(enumerable2, 5..^4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(^5..6);
		b = E.Take(enumerable2, ^5..6);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(^10..9);
		b = E.Take(enumerable2, ^10..9);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.Take(^5..^2);
		b = E.Take(enumerable2, ^5..^2);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
	}

	[TestMethod]
	public void TestTakeLast()
	{
		var a = list.TakeLast(4);
		var b = E.TakeLast(list, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.TakeLast(1000);
		b = E.TakeLast(list, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = list.TakeLast(-5);
		b = E.TakeLast(list, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.TakeLast(4);
		b = E.TakeLast(enumerable, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.TakeLast(1000);
		b = E.TakeLast(enumerable, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable.TakeLast(-5);
		b = E.TakeLast(enumerable, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.TakeLast(4);
		b = E.TakeLast(enumerable2, 4);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.TakeLast(1000);
		b = E.TakeLast(enumerable2, 1000);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
		a = enumerable2.TakeLast(-5);
		b = E.TakeLast(enumerable2, -5);
		Assert.IsTrue(a.Equals(b));
		Assert.IsTrue(E.SequenceEqual(b, a));
	}
}
