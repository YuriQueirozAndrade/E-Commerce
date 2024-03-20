namespace Back_End.Interfaces
{
    public interface ICart<TEntity>
    where TEntity : class
    {
        public string UserId { get; set;}
        List<TEntity> ToOrderItemList();
        public List<int> ToProductIDList();
        public List<int> ToProductQuantityList();
    }
}