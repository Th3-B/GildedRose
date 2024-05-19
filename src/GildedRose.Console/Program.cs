using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GildedRose.Console
{
	public class Program
	{
		IList<Item> Items;
		public Program()
		{
			
		}
		public Program(IList<Item> items)
		{
			Items = items;
		}
		static void Main(string[] args)
		{
			System.Console.WriteLine("OMGHAI!");

			var app = new Program() {
				Items = new List<Item> {
					new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
					new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
					new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
					new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
					new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
					new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
				}
			};

			app.UpdateQuality();

			System.Console.ReadKey();

		}

		public void UpdateQuality()
		{
			try
			{
				Items.ToList().ForEach(item => {
					if (item.Name?.ToLower()?.Trim()?.Contains("aged brie") ?? false)
						new ItemOperations(new AgedBreeItem(item)).UpdateQuality();
					else if (item.Name?.ToLower()?.Trim()?.Contains("backstage passes") ?? false)
						new ItemOperations(new BackstagePassItem(item)).UpdateQuality();
					else if (item.Name?.ToLower()?.Trim()?.Contains("sulfuras") ?? false)
						new ItemOperations(new SulfurasItem(item)).UpdateQuality();
					else if (item.Name?.ToLower()?.Trim()?.Contains("conjured") ?? false)
						new ItemOperations(new ConjuredItem(item)).UpdateQuality();
					else
						new ItemOperations(new RegularItem(item)).UpdateQuality();
				});
			}
			catch (System.Exception ex)
			{
				string err = ex.Message;
			}
		}

	}

	public class Item
	{
		public string Name { get; set; }

		public int SellIn { get; set; }

		public int Quality { get; set; }
	}

	public interface IItemOperations
	{
		void UpdateQuality();
	}

	public class AgedBreeItem : IItemOperations
	{
		private Item _item;
		public AgedBreeItem(Item item)
		{
			_item = item;
		}
		public void UpdateQuality()
		{
			if (_item.SellIn <= 0 && _item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			if (_item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			_item.SellIn = _item.SellIn - 1;
		}
	}
	public class BackstagePassItem : IItemOperations
	{
		private Item _item;
		public BackstagePassItem(Item item)
		{
			_item = item;
		}
		public void UpdateQuality()
		{
			if (_item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			if (_item.Quality < 50 && _item.SellIn < 11 && _item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			if (_item.Quality < 50 && _item.SellIn < 6 && _item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			if (_item.SellIn <= 0)
				_item.Quality = _item.Quality - _item.Quality;
			_item.SellIn = _item.SellIn - 1;
		}
	}
	public class SulfurasItem : IItemOperations
	{
		private Item _item;
		public SulfurasItem(Item item)
		{
			_item = item;
		}
		public void UpdateQuality()
		{
		}
	}
	public class ConjuredItem : IItemOperations
	{
		private Item _item;
		public ConjuredItem(Item item)
		{
			_item = item;
		}
		public void UpdateQuality()
		{
			_item.Quality = _item.Quality - 2;
			if (_item.SellIn <= 0)
				_item.Quality = _item.Quality - 2;
			_item.SellIn = _item.SellIn - 1;
		}
	}
	public class RegularItem : IItemOperations
	{
		private Item _item;
		public RegularItem(Item item)
		{
			_item = item;
		}
		public void UpdateQuality()
		{
			if (_item.Quality > 0)
				_item.Quality = _item.Quality - 1;
			if (_item.SellIn < 0 && _item.Quality > 0)
				_item.Quality = _item.Quality - 1;
			_item.SellIn = _item.SellIn - 1;
		}
	}
	public class ItemOperations
	{
		private readonly IItemOperations _itemOperations;
        public ItemOperations(IItemOperations itemOperations)
        {
			_itemOperations = itemOperations;
		}
		public void UpdateQuality()
		{
			_itemOperations.UpdateQuality();
		}
	}
}
