using NUnit.Framework;
using UnityEngine;

public class TestPoint
{
	[Test]
	public void InitializeValidData()
	{
		Point point = new Point (1.0f, 2.0f);
		Assert.AreEqual (1.0f, point.X);
		Assert.AreEqual (2.0f, point.Y);
	}

	[Test]
	public void SetValidData() {
		Point point = new Point (1.0f, 2.0f);
		point.X = 3.0f;
		point.Y = 4.0f;
		Assert.AreEqual (3.0f, point.X);
		Assert.AreEqual (4.0f, point.Y);

		point.SetPoint (8.0f, 9.0f);
		Assert.AreEqual (8.0f, point.X);
		Assert.AreEqual (9.0f, point.Y);
	}
}

