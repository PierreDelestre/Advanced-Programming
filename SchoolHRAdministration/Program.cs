using HRAdministrationAPI;
using System.Linq;

// See https://aka.ms/new-console-template for more information
decimal totalSalaries = 0;
List<IEmployee> employees = new List<IEmployee>();

SeedData(employees);

//foreach (var employee in employees)
//{
//    totalSalaries += employee.Salary;
//}

//Console.WriteLine($"Total annual salaries (including bonus): {totalSalaries}");

Console.WriteLine($"Total annual salaries (including bonus): {employees.Sum(e => e.Salary)}");
Console.ReadKey();

static void SeedData(List<IEmployee> employees)
{
    IEmployee teacher1 = new Teacher
    {
        ID = 1,
        FirstName = "Bob",
        LastName = "Fisher",
        Salary = 40000
    };

    employees.Add(teacher1);

    IEmployee teacher2 = new Teacher
    {
        ID = 2,
        FirstName = "Jenny",
        LastName = "Thomas",
        Salary = 40000
    };

    employees.Add(teacher2);

    IEmployee headOfDepartment = new HeadOfDepartment
    {
        ID = 3,
        FirstName = "Brenda",
        LastName = "Mullins",
        Salary = 50000
    };

    employees.Add(headOfDepartment);

    IEmployee deputyHeadMaster = new DeputyHeadMaster
    {
        ID = 4,
        FirstName = "Devlin",
        LastName = "Brown",
        Salary = 60000
    };

    employees.Add(deputyHeadMaster);

    IEmployee headMaster = new HeadMaster
    {
        ID = 5,
        FirstName= "Damien",
        LastName = "Jones",
        Salary = 80000
    };

    employees.Add(headMaster);
}

public class Teacher: EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); set => base.Salary = value; }
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); set => base.Salary = value; }

}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); set => base.Salary = value; }

}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); set => base.Salary = value; }

}
