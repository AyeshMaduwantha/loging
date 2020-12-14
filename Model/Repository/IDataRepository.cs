using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loginAssignment.Model.Repository
{
     public interface IDataRepository<TEntity>
    {
        UserModel Authenticate(string username, string password);
        List<UserModel> GetAll();
       // IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
