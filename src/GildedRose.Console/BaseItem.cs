namespace GildedRose.Console
{
	public class BaseItem : Item
	{
		public Item _item { get; }
		public BaseItem(Item item)
		{
			_item = item;
		}
		/// <summary>
		/// This is default for regular items, can be replaced by overriding this method
		/// </summary>
		public virtual void UpdateQuality()
		{
			if (_item.Quality > 0)
				_item.Quality = _item.Quality - 1;
			if (_item.SellIn < 0 && _item.Quality > 0)
				_item.Quality = _item.Quality - 1;
			_item.SellIn = _item.SellIn - 1;
		}
	}
}
