namespace Core.MongoStudio.Adapters
{
    internal abstract class Adapter
    {
        public bool HasError { get; set; } = false;
    }
}