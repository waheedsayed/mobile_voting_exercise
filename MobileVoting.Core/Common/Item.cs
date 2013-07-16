namespace MobileVoting.Core.Common
{
    /// <summary>
    /// Handy Key/Value pair object for difference scenarios
    /// </summary>
    public class Item<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
