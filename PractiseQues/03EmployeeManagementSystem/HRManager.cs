class HRManager
{
    private SortedDictionary<int, Employee> emp = new SortedDictionary<int, Employee>();
    public void AddEmployee(string name, string dept, double salary)
    {
        int id = emp.Count + 1;
        emp.Add(id, new Employee
        {
            Name = name, Department = dept, Salary = salary, JoiningDate = DateTime.Now
        });
    }
    
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        return new SortedDictionary<string, List<Employee>>(
            emp.Values.GroupBy(e => e.Department).ToDictionary(g => g.Key, g => g.ToList())
    );}

    public double CalculateDepartmentSalary(string department)
    {
        return emp.Values
            .Where(e => e.Department == department)
            .Sum(e => e.Salary);
    }
    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        return emp.Values
            .Where(e => e.JoiningDate > date)
            .ToList();
    }
}