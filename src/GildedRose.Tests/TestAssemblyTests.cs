using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
	public class TestAssemblyTests
	{
		[Fact]
		public void TestTheTruth()
		{
			Assert.True(true);
		}
		public Program CreateProgramInstance(Item item)
		{
			IList<Item> itemList = new List<Item>() { item };
			return new Program(itemList);
		}

		#region At the end of each day our system lowers both values for every item
		[Fact]
		//Test: At the end of each day our system lowers quality
		public void TestQualityDecrese()
		{
			Item testItem = new Item() { Name = "Test Item", Quality = 20, SellIn = 10 };

			Program appTest = CreateProgramInstance(testItem);
			appTest.UpdateQuality();

			Assert.Equal(19, testItem.Quality);
		}

		[Fact]
		//Test: At the end of each day our system lowers SellIn
		public void TestSellInDecrese()
		{
			Item testItem = new Item() { Name = "Test Item", Quality = 20, SellIn = 10 };

			Program appTest = CreateProgramInstance(testItem);
			appTest.UpdateQuality();

			Assert.Equal(9, testItem.SellIn);
		}
		#endregion

		#region Once the sell by date has passed, Quality degrades twice as fast
		[Fact]
		//Test: Quality is decresed twise when sell by date has passed
		public void TestQualityDecreseTwiseWhenSellInPassed()
		{
			Item testItem = new Item() { Name = "Test Item", Quality = 20, SellIn = -1 };

			Program appTest = CreateProgramInstance(testItem);
			appTest.UpdateQuality();

			Assert.Equal(18, testItem.Quality);
		}
		#endregion

		#region The Quality of an item is never negative
		[Theory]
		[InlineData(3)]
		[InlineData(0)]
		[InlineData(-2)]
		//Test: Qulity is never negative
		public void TestIsQualityPositive(int sellIn)
		{
			Item testItem = new Item() { Name = "Test Item", Quality = 0, SellIn = sellIn };

			Program appTest = CreateProgramInstance(testItem);
			appTest.UpdateQuality();

			Assert.Equal(0, testItem.Quality);
		}
		#endregion

		#region "Aged Brie" actually increases in Quality the older it gets
		[Fact]
		//Test: AgedBrie increases quality the older it gets
		public void TestAgedBrieQualityIncrease()
		{
			Item agedBrieItem = new Item() { Name = "Aged Brie", Quality = 10, SellIn = 5 };

			Program appTest = CreateProgramInstance(agedBrieItem);
			appTest.UpdateQuality();

			Assert.Equal(11, agedBrieItem.Quality);
		}
		[Theory]
		[InlineData(0)]
		[InlineData(-3)]
		//Test: AgedBrie increases quality the older it gets
		public void TestAgedBrieQualityIncreaseAfterSellIn(int sellIn)
		{
			Item agedBrieItem = new Item() { Name = "Aged Brie", Quality = 10, SellIn = sellIn };

			Program appTest = CreateProgramInstance(agedBrieItem);
			appTest.UpdateQuality();

			Assert.Equal(12, agedBrieItem.Quality);
		}
		#endregion

		#region The Quality of an item is never more than 50
		[Fact]
		//Test: Quality of an item is never more than 50
		public void TestItemMaxQuality()
		{
			Item agedBrieItem = new Item() { Name = "Aged Brie", Quality = 50, SellIn = 15 };

			Program appTest = CreateProgramInstance(agedBrieItem);
			appTest.UpdateQuality();

			Assert.Equal(50, agedBrieItem.Quality);
		}
		#endregion

		#region "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
		[Fact]
		//Test: Sulfuras never decreases in quality
		public void TestSulfurasQuality()
		{
			Item sulfurasItem = new Item() { Name = "Sulfuras, Hand of Ragnaros", Quality = 15, SellIn = 18 };

			Program appTest = CreateProgramInstance(sulfurasItem);
			appTest.UpdateQuality();

			Assert.Equal(15, sulfurasItem.Quality);
		}

		[Fact]
		//Test: Sulfuras never decreases in SellIn
		public void TestSulfurasSellIn()
		{
			Item sulfurasItem = new Item() { Name = "Sulfuras, Hand of Ragnaros", Quality = 15, SellIn = 18 };

			Program appTest = CreateProgramInstance(sulfurasItem);
			appTest.UpdateQuality();

			Assert.Equal(18, sulfurasItem.SellIn);
		}
		#endregion

		#region "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less	and by 3 when there are 5 days or less but Quality drops to 0 after the concert
		[Theory]
		[InlineData(30)]
		[InlineData(11)]
		//Test: Backstage passes increases quality the older it gets
		public void TestBackstagePassesQualityIncrease(int sellIn)
		{
			Item backstageItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 11, SellIn = sellIn };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(12, backstageItem.Quality);
		}

		[Theory]
		[InlineData(10)]
		[InlineData(6)]
		//Test: Backstage passes increases quality by 2 when there are 10 days or less
		public void TestBackstagePassesQualityIncreaseTwoTimes(int sellIn)
		{
			Item backstageItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = sellIn };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(12, backstageItem.Quality);
		}

		[Theory]
		[InlineData(5)]
		[InlineData(3)]
		[InlineData(1)]
		//Test: Backstage passes increases quality by 3 when there are 5 days or less
		public void TestBackstagePassesQualityIncreaseThreeTimes(int sellIn)
		{
			Item backstageItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 7, SellIn = sellIn };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(10, backstageItem.Quality);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-5)]
		//Test: Backstage passes drops quality to 0 once the sellin has passed.
		public void TestBackstagePassesQualityTo0(int sellIn)
		{
			Item backstageItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 7, SellIn = sellIn };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(0, backstageItem.Quality);
		}
		#endregion

		#region "Conjured" items degrade in Quality twice as fast as normal items
		[Fact]
		//Test: Conjured items degrade in Quality twice as fast as normal items
		public void TestConjuredQualityToDegrade()
		{
			Item backstageItem = new Item() { Name = "Conjured", Quality = 8, SellIn = 4 };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(6, backstageItem.Quality);
		}
		[Fact]
		//Test: Conjured items degrade in Quality twice as fast as normal items
		public void TestConjuredQualityToDegradeAfterSellIn()
		{
			Item backstageItem = new Item() { Name = "Conjured", Quality = 8, SellIn = 0 };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(4, backstageItem.Quality);
		}
		[Fact]
		//Test: Conjured items degrade in Quality twice as fast as normal items
		public void TestConjuredSellInDecrease()
		{
			Item backstageItem = new Item() { Name = "Conjured", Quality = 8, SellIn = 4 };

			Program appTest = CreateProgramInstance(backstageItem);
			appTest.UpdateQuality();

			Assert.Equal(3, backstageItem.SellIn);
		}
		#endregion
	}
}