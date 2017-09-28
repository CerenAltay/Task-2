using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager staff = new Manager();
            Console.WriteLine(staff.Operate());
            staff.HireEmployee("Alison Lite");

            Department HR = new Department();
            Console.WriteLine(HR.Operate());
            Department.WriteInvoice();

            List<Employee> employees = new List<Employee>();


            employees.Add(new Manager()
            {
                EmployeeName = "Lara Den",
                EmployeeID = 1
            });

            employees.Add(new Manager()
            {
                EmployeeName = "Fern Cotton",
                EmployeeID = 2
            });

            foreach (var person in employees)
            {
                Console.WriteLine("{0} {1}", person.EmployeeID, person.EmployeeName);
                person.UseHoliday(15);
                person.UseHoliday(32);
            }
            Console.ReadLine();
        }
    }

    public abstract class Employee
    {
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }

        public abstract string Operate();

        public void UseHoliday(int holiday)
        {
            int allowedHolidays = 30;
            int remainingHolidays = (allowedHolidays - holiday);

            try
            {
                int holidaysToUse = remainingHolidays > 0 ? (allowedHolidays - holiday) : 0;
                int holidayRatio = allowedHolidays / holidaysToUse;


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                //why do I need a custom exception? is it a warning to the developer? 
                throw new Exception("Holiday limit exceeded!");
            }

            finally
            {
                Console.WriteLine("Holidays left is" + "=" + "{0} days", remainingHolidays);
            }
        }
    }

    public class Manager : Employee
    {

        public override string Operate()
        {
            return "This manager works 4 days a week";
        }

        public string HireEmployee(string manager)
        {
            EmployeeName = "Julie Hays";

            return string.Format("Manager {0} hires {1}", manager, EmployeeName);
        }
    }

    public class Department : Employee
    {
        public override string Operate()
        {
            return "This department operates 5 days a week";
        }
        public static void WriteInvoice()
        {
            ArrayList invoicePerMonth = new ArrayList();

            for (int i = 0; i < 11; i++)
            {
                invoicePerMonth.Add(2000);
            }

            foreach (var salary in invoicePerMonth)
            {
                Console.WriteLine("Your salary has been paid. ");
            }
        }
    }
}
