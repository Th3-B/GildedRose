namespace GildedRose.Console
{
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
}
