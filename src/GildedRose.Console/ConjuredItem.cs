namespace GildedRose.Console
{
	public class ConjuredItem : BaseItem
	{
		public ConjuredItem(Item item) : base(item) { }
		public override void UpdateQuality()
		{
			_item.Quality = _item.Quality - 2;
			if (_item.SellIn <= 0)
				_item.Quality = _item.Quality - 2;
			_item.SellIn = _item.SellIn - 1;
		}
	}
}