using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Infrastructure.Data;

namespace E_Commerce_API.Infrastructure.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DataBaseContext _dataBaseContext;
        public UnityOfWork(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task Commit()
        {
            await _dataBaseContext.SaveChangesAsync();
        }
        public async Task RollBack()
        {
             Console.WriteLine("inplements the rollback now, stupid ");
        }
    }
}
