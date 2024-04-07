namespace E_Commerce_API.Application.Interfaces
{
    public interface IUnityOfWork 
    {
        public Task Commit();
        public Task RollBack();
    }
}