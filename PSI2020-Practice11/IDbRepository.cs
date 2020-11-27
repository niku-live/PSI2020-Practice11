using System.Collections.Generic;
using PSI2020_Practice11.Models;

namespace PSI2020_Practice11
{
    public interface IDbRepository
    {
        List<Employee> Employees { get; }

        void SaveChanges();
    }
}