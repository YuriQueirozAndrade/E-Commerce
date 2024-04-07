namespace E_Commerce_API.Application.Interfaces.DTOs
{
    public interface IDTO<TEntity> where TEntity : class
    {
        void UpdateEntity(TEntity entity);
        TEntity ToEntity();
    }
}