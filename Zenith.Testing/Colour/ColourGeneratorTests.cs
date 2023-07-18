﻿using NUnit.Framework;
using Zenith.Colour;

namespace Zenith.Testing.Colour
{
	[TestFixture]
	public class ColourGeneratorTests
	{
		[Test]
		[TestCase(128 * 128)]
		[TestCase(256 * 256)]
		[TestCase(2560 * 1440)]
		[TestCase(4096 * 4096)]
		public void Counts_Uniform(int pixels)
		{
			var coloursRGB = ColourGenerator.GenerateColours_RGB_Uniform(pixels);
			Assert.AreEqual(pixels, coloursRGB.Count, "RGB uniform");

			var coloursHSB = ColourGenerator.GenerateColours_HSB_Uniform(pixels);
			Assert.AreEqual(pixels, coloursHSB.Count, "RGB uniform");
		}

		[Test]
		[TestCase(128 * 128)]
		[TestCase(256 * 256)]
		[TestCase(512 * 512)]
		[TestCase(1024 * 1024)]
		public void Counts_Pastel(int pixels)
		{
			var coloursPastelRGB = ColourGenerator.GenerateColours_RGB_Pastel(pixels);
			Assert.AreEqual(pixels, coloursPastelRGB.Count, "RGB pastel");

			var coloursPastelHSB = ColourGenerator.GenerateColours_HSB_Uniform(pixels);
			Assert.AreEqual(pixels, coloursPastelHSB.Count, "HSB pastel");
		}

		[Test]
		[TestCase(2560 * 1440)]
		[TestCase(2048 * 2048)]
		[TestCase(4096 * 4096)]
		public void Counts_PastelFail(int pixels)
		{
			Assert.Multiple(() =>
			{
				_ = Assert.Throws<ArgumentOutOfRangeException>(() => ColourGenerator.GenerateColours_RGB_Pastel(pixels), "RGB pastel");
				_ = Assert.Throws<ArgumentOutOfRangeException>(() => ColourGenerator.GenerateColours_HSB_Pastel(pixels), "HSB pastel");
			});
		}

		[Test]
		public void Counts_DefaultDomainSize()
			=> _ = Assert.Throws<ArgumentOutOfRangeException>(() => ColourGenerator.GenerateColours_Uniform<ColourRGB>((int)Math.Pow(2, 24) + 1, ColourGenerator.DefaultDomain));

		[Test]
		public void FullTest()
		{
			var colours = ColourGenerator.GenerateColours_RGB_Uniform(3 * 3 * 3);
			Assert.AreEqual(27, colours.Count);

			Assert.Multiple(() =>
			{

				Assert.That(colours.Contains(new ColourRGB(0f, 0f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 0f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 0f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 0.5f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 0.5f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 0.5f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 1f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 1f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0f, 1f, 1f)));

				Assert.That(colours.Contains(new ColourRGB(0.5f, 0f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 0f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 0f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 0.5f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 0.5f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 0.5f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 1f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 1f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(0.5f, 1f, 1f)));

				Assert.That(colours.Contains(new ColourRGB(1f, 0f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 0f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 0f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 0.5f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 0.5f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 0.5f, 1f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 1f, 0f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 1f, 0.5f)));
				Assert.That(colours.Contains(new ColourRGB(1f, 1f, 1f)));
			});
		}
	}
}
