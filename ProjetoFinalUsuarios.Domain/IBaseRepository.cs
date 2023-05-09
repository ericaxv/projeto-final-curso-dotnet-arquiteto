using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="IEntity">Tipo da Entidade</typeparam>
    /// <typeparam name="TKey">Tipo do Id da Entidade</typeparam>
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(TKey id);
    }
}
