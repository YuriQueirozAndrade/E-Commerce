namespace E_Commerce_API.Application.Interfaces.DTOs
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