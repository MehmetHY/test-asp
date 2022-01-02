using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoData.Data.Interfaces;

namespace TodoData.Data
{
    public class ProcedureCaller : IProcedureCaller
    {
        private readonly string _connectionString;

        public ProcedureCaller(string connectionString)
        {
            using (T connection = new T(connectionString))
            {

            }
        }

        public void Execute(string procedureName, DynamicParameters? parameters = null)
        {
            throw new NotImplementedException();
        }

        public T GetValue<T>(string procedureName, DynamicParameters? parameters = null)
        {
            throw new NotImplementedException();
        }

        public T GetRow<T>(string procedureName, DynamicParameters? parameters = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetRows<T>(string procedureName, DynamicParameters? parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
