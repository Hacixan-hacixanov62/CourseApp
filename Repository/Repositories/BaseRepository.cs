using Domain.Comman;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
           AppDbContent<T>.datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContent<T>.datas.Remove(entity);
        }

        public List<T> GetAll()
        {
            return AppDbContent<T>.datas.ToList();
        }

        public List<T> GetAllWithExpression(Func<T, bool> predicate)
        {
           return  AppDbContent<T>.datas.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return AppDbContent<T>.datas.FirstOrDefault(m => m.Id ==id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
