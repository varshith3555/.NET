using System.Collections.Generic;

namespace EmployeeApp.Core
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public int GetEmployeeCount()
        {
            return repository.GetAll().Count;
        }
    }
}