using Dapper;
using System.Dynamic;
using TodoData.Data.Interfaces;
using TodoData.Repository.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoData.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IProcedureCaller _pc;
        public Repository(IProcedureCaller pc)
        {
            _pc = pc;
        }

        private bool ShouldProcess()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.CustomAttributes.Any(attrib => attrib.AttributeType == typeof(NotMappedAttribute)))
                { 
                    return false; 
                }
                if (prop.CustomAttributes.Any(attrib => attrib.AttributeType == typeof(KeyAttribute)))
                {
                    return false;
                }
                if (prop.Name == "Id")
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(T entity)
        {
            var parameters = new DynamicParameters();
            foreach (var prop in entity.GetType().GetProperties())
            {
                if (!ShouldProcess()) continue;
                if (prop.Name != "Id")
                    parameters.Add(prop.Name, prop.GetValue(entity));
            }
            _pc.Execute("Add", parameters);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public T? Get(int id)
        {
            
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
