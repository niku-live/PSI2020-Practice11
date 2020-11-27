using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PSI2020_Practice11
{
    public class DbRepository : IDbRepository
    {
        private readonly string Path = @"C:\Users\kuosis\Desktop\employees.json";
        private List<Models.Employee> _employees = null;

        public List<Models.Employee> Employees { get => _employees ?? (_employees = LoadEmployees()); }

        private List<Models.Employee> LoadEmployees()
        {
            var data = System.IO.File.ReadAllText(Path);
            return JsonSerializer.Deserialize<Models.Employee[]>(data).ToList();

        }

        public void SaveChanges()
        {
            var data = JsonSerializer.Serialize<Models.Employee[]>(_employees.ToArray());
            System.IO.File.WriteAllText(Path, data);
        }
    }
}
