namespace Back_End.Interfaces
{
    public interface IResponseDTO<TEntity>
    where TEntity : class
    {
        IDTO<TEntity> ToDto(TEntity entity);
        List<IDTO<TEntity>> ToDtoList(List<TEntity> entities);
    }
}