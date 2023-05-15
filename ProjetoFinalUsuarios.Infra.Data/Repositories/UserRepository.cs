using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using ProjetoFinalUsuarios.Infra.Data.Contexts;
using ProjetoFinalUsuarios.Infra.Data.Helpers;

namespace ProjetoFinalUsuarios.Infra.Data.Repositories
{
    public class UserRepository :  BaseRepository<User, Guid>, IUserRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        /// <summary>
        /// Construtor de injeção de dependencia.
        /// </summary>
        /// <param name="sqlServerContext"></param>
        public UserRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Create(User entity)
        {
            entity.Password = MD5Helper.Encrypt(entity.Password);
            base.Create(entity);
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return _sqlServerContext
                   .User
                   .FirstOrDefault(x => x.Email.Equals( email));
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            var passwordEncrypt = MD5Helper.Encrypt(password);
            return _sqlServerContext.User.SingleOrDefault(x => x.Email.Equals(email) 
                                             && x.Password.Equals(passwordEncrypt));
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity, User entityToUpdate)
        {
            entityToUpdate.Password = MD5Helper.Encrypt(entityToUpdate.Password);
            base.Update(entity, entityToUpdate);
        }
    }
}
