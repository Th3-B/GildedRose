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
			try
			{
				Items.ToList().ForEach(item => {

					// UPDATED ITEM IDENTIFIER TO FIND ITEM WITH CONTAINS EXPRESSION.
					switch (item.Name)
					{
						case string itemName when itemName?.ToLower()?.Trim()?.Contains("aged brie") ?? false:
							new ItemOperations(new AgedBreeItem(item)).UpdateQuality();
							break;
						case string itemName when itemName?.ToLower()?.Trim()?.Contains("backstage passes") ?? false:
							new ItemOperations(new BackstagePassItem(item)).UpdateQuality();
							break;
						case string itemName when itemName?.ToLower()?.Trim()?.Contains("sulfuras") ?? false:
							new ItemOperations(new SulfurasItem(item)).UpdateQuality();
							break;
						case string itemName when itemName?.ToLower()?.Trim()?.Contains("conjured") ?? false:
							new ItemOperations(new ConjuredItem(item)).UpdateQuality();
							break;
						default:
							new ItemOperations(new RegularItem(item)).UpdateQuality();
							break;
					}
					/* THIS SWITCH CASE WILL CHECK FOR CASE SENSITIVE NAMES 
					switch (item.Name)
					{
						case "Aged Brie":
							new ItemOperations(new AgedBreeItem(item)).UpdateQuality();
							break;
						case "Backstage passes to a TAFKAL80ETC concert":
							new ItemOperations(new BackstagePassItem(item)).UpdateQuality();
							break;
						case "Sulfuras, Hand of Ragnaros":
							new ItemOperations(new SulfurasItem(item)).UpdateQuality();
							break;
						case "Conjured Mana Cake":
							new ItemOperations(new ConjuredItem(item)).UpdateQuality();
							break;
						default:
							new ItemOperations(new RegularItem(item)).UpdateQuality();
							break;
					}
					*/
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
}
