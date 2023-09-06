using Microsoft.EntityFrameworkCore;
using tran1.Models;

namespace tran1.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly CRContext _context;
        private readonly DbSet<TEntity> _dbset;
        public GenericRepository(CRContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        
        public List<TEntity> GetAll()
        {
            return _dbset.ToList();
        }
        public TEntity GetById(int Id)
        {
            return _dbset.Find(Id);
        }
        public void Create(TEntity entity)
        {
            _dbset.Add(entity);
        }


        public void Update(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }


        public void SaveChange()
        {
            _context.SaveChanges();
        }

    }
}
