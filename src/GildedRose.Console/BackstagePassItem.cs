namespace GildedRose.Console
{
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
			if (_item.Quality < 50 && _item.SellIn < 11)
				_item.Quality = _item.Quality + 1;
			if (_item.Quality < 50 && _item.SellIn < 6)
				_item.Quality = _item.Quality + 1;
			if (_item.SellIn <= 0)
				_item.Quality = _item.Quality - _item.Quality;
			_item.SellIn = _item.SellIn - 1;
		}
	}
}
