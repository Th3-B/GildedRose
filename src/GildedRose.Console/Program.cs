using System.Collections.Generic;
using System.Linq;

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
			Items.ToList().ForEach(item => {
				if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros" && item.Quality > 0)
				{
					item.Quality = item.Quality - 1;
				}
				if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Quality < 50)
				{
					item.Quality = item.Quality + 1;
				}
				if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 11 && item.Quality < 50)
				{
					item.Quality = item.Quality + 1;
				}
				if ((item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert") && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 6 & item.Quality < 50)
				{
					item.Quality = item.Quality + 1;
				}
				if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					item.SellIn = item.SellIn - 1;
				}
				if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros" && item.Quality > 0 && item.SellIn < 0)
				{
					item.Quality = item.Quality - 1;
				}
				if (item.Name != "Aged Brie" && item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.SellIn < 0)
				{
					item.Quality = item.Quality - item.Quality;
				}
				if (item.Name == "Aged Brie" && item.Quality < 50 && item.SellIn < 0)
				{
					item.Quality = item.Quality + 1;
				}
			});
		}

	}

	public class Item
	{
		public string Name { get; set; }

		public int SellIn { get; set; }

		public int Quality { get; set; }
	}

}
