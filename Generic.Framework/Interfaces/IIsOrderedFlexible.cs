namespace Generic.Framework.Interfaces
{
    public interface IIsOrderedFlexible
    {
        /// <summary>
        /// It is intended that ordering in with this field can be done in a flexible way. Example: 0, 1, 1.000000001, 1.000000002, 3, 4
        /// This allows for items to be reordered by editing the order value for only one item
        /// </summary>
        decimal Order { get; set; }
    }
}
