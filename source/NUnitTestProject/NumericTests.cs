using NumericUpDownLib;
using NumericUpDownLib.Base;
using NUnit.Framework;
using System;
using System.Threading;

namespace NUnitTestProject
{
	[Apartment(ApartmentState.STA)]
	public class NumericTests
	{
		[SetUp]
		public void Setup()
		{
		}

		/// <summary>
		/// Tests whether values are set correctly as required while maintaining
		/// valid values at all times.
		/// </summary>
		[Test]
		public void TestValues()
		{
			TestAllPermutations(25, 50, 75);
			TestAllPermutations(-25, 50, 75);
			TestAllPermutations(-50, -50, 75);
			TestAllPermutations(50, 50, 50);
			TestAllPermutations(-50, -50, -50);
		}

		/// <summary>
		/// Tests all permutions for all sequences of three elements.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="val"></param>
		/// <param name="max"></param>
		public void TestAllPermutations(int min, int val, int max)
		{
			string[,] ctrl = new string[6, 3]
			{
				{ "min", "val", "max" },
				{ "val", "min", "max" },
				{ "val", "max", "min" },
				{ "val", "min", "max" },
				{ "min", "max", "val" },
				{ "max", "min", "val" },
			};

			for (int i = 0; i < 6; i++)
			{
				var range = new NumericUpDown();
				string testPermutation = "";

				for (int j = 0; j < 3; j++)
				{
					var itemToSet = ctrl[i, j];

					if (string.IsNullOrEmpty(testPermutation))
						testPermutation = itemToSet;
					else
						testPermutation += ", " + itemToSet;

					switch (itemToSet)
					{
						case "min":
							range.MinValue = min;
							Assert.IsTrue(IsValidRange(range));
							break;

						case "val":
							range.Value = val;
							Assert.IsTrue(IsValidRange(range));
							break;

						case "max":
							range.MaxValue = max;
							Assert.IsTrue(IsValidRange(range));
							break;

						default:
							break;
					}
				}

				Console.WriteLine("Testing Permutation {0}: {1} - min={2}, val={3}, max={4}", i, testPermutation, min, val, max);
				Assert.IsTrue(IsValidRange(range));

				Assert.IsTrue(range.MinValue == min);
				Assert.IsTrue(range.Value == val);
				Assert.IsTrue(range.MaxValue == max);

				// Test if increment command works as expected
				while (range.MaxValue > range.Value)
				{
					Assert.IsTrue(InputBaseUpDown.IncreaseCommand.CanExecute(null, range));
					InputBaseUpDown.IncreaseCommand.Execute(null, range);
				}
				Assert.IsTrue(range.MaxValue == range.Value);

				// Test if decrement command works as expected
				while (range.MinValue < range.Value)
				{
					Assert.IsTrue(InputBaseUpDown.DecreaseCommand.CanExecute(null, range));
					InputBaseUpDown.DecreaseCommand.Execute(null, range);
				}
				Assert.IsTrue(range.MinValue == range.Value);
			}
		}

		/// <summary>
		/// Determines whether the given set of values defines a valid range or not.
		/// A valid range adheres to this constrain: MinValue <= Value <= MaxValue.
		/// </summary>
		/// <param name="range"></param>
		/// <returns></returns>
		bool IsValidRange(NumericUpDown range)
		{
			if (range.MinValue <= range.Value && range.Value <= range.MaxValue)
				return true;

			return false;

		}
	}
}
