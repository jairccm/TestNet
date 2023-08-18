using System;
using System.Data;

namespace Assessment.JCCM.DAL.Interfaces
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
