namespace GildedRose.Console
{
	public class AgedBreeItem : BaseItem
	{
		public AgedBreeItem(Item item) : base(item) { }
		public override void UpdateQuality()
		{
			if (_item.SellIn <= 0 && _item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			if (_item.Quality < 50)
				_item.Quality = _item.Quality + 1;
			_item.SellIn = _item.SellIn - 1;
		}
	}
}