﻿using HRAdministrationAPI;

// See https://aka.ms/new-console-template for more information
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
    IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
    IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
    IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Brenda", "Mullins", 50000);
    IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Devlin", "Brown", 60000);
    IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);

    employees.Add(teacher1);
    employees.Add(teacher2);
    employees.Add(headOfDepartment);
    employees.Add(deputyHeadMaster);
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

public enum EmployeeType
{
    Teacher,
    HeadOfDepartment,
    DeputyHeadMaster,
    HeadMaster
}

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = null;

        switch (employeeType)
        {
            case EmployeeType.Teacher:
                employee = FactoryPattern<IEmployee,Teacher>.GetInstance();
                break;
            
            case EmployeeType.HeadMaster:
                employee = FactoryPattern<IEmployee,HeadMaster>.GetInstance();
                break;
            
            case EmployeeType.HeadOfDepartment:
                employee = FactoryPattern<IEmployee,HeadOfDepartment>.GetInstance();
                break;
            
            case EmployeeType.DeputyHeadMaster:
                employee = FactoryPattern<IEmployee,DeputyHeadMaster>.GetInstance();
                break;
            
            default:
                break;
        }

        if (employee != null)
        {
            employee.ID = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }
        else
        {
            throw new NullReferenceException();
        }
        
        return employee;
    }
}

