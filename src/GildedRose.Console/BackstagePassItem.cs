namespace GildedRose.Console
{
	public class BackstagePassItem : BaseItem
	{
		public BackstagePassItem(Item item) : base(item) { }
		public override void UpdateQuality()
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