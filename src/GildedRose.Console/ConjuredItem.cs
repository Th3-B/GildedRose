namespace GildedRose.Console
{
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
}
