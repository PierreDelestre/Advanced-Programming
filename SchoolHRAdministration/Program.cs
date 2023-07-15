using HRAdministrationAPI;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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


}

public class Teacher: EmployeeBase
{

}

public class HeadOfDepartment : EmployeeBase
{

}

public class DeputyHeadMaster : EmployeeBase
{

}

public class HeadMaster : EmployeeBase
{

}
