using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Worker : Human
    {
        private string firstName;
        private string lastName;
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("WeekSalary", "The week salary can not be a negative number");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("WorkHoursPerDay", "The work hours per day can not be a negative number");
                }
                this.workHoursPerDay = value;
            }
        }

        public string MoneyPerHour()
        {
            double moneyPerHour = Math.Round(((this.weekSalary / 5) / this.workHoursPerDay), 2);
            return moneyPerHour + "$/hour";
        }
    }
}