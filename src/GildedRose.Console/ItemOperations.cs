namespace GildedRose.Console
{
	public class ItemOperations
	{
		private readonly IItemOperations _itemOperations;
		public ItemOperations(IItemOperations itemOperations)
		{
			_itemOperations = itemOperations;
		}
		public virtual void UpdateQuality()
		{
			_itemOperations.UpdateQuality();
		}
	}
}
