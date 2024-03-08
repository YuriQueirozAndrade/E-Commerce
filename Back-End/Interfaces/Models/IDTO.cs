namespace Back_End.Interfaces
{
    public interface IDTO<TEntity> where TEntity : class
    {
        void UpdateEntity(TEntity entity);
        TEntity ToEntity();
    }
}