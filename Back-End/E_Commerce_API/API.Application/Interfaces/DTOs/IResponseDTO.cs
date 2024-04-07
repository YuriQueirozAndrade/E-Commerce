namespace E_Commerce_API.Application.Interfaces.DTOs
{
    public interface IResponseDTO<TEntity>
    where TEntity : class
    {
        IDTO<TEntity> ToDto(TEntity entity);
        List<IDTO<TEntity>> ToDtoList(List<TEntity> entities);
    }
}