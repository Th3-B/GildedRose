namespace GildedRose.Console
{
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
}
