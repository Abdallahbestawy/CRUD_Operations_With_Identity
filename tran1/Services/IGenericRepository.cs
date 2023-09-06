using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace tran1.Services
{ 
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChange();
    }
}
