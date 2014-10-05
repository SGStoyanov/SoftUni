using System;
using System.Collections.Generic;

class CompanyTester
{
    static void Main()
    {
        var computer = new Sale("Lenovo","12-12-2014", 650);
        var dvd = new Sale("Philips", "12-12-2015", 300);
        var tv = new Sale("Samsung", "12-12-2016", 620);

        var john = new SalesEmployee(8120403565, "John", "Carera", 1500, Department.Production, dvd);
        var ivan = new SalesEmployee(85264040262, "Ivan", "Smallhouse", 5200, Department.Sales, computer, tv);

        var ludnica = new Project("gospodari.bg", "05-07-1947", "some details");
        var web = new Project("home.bg", "04-04-1984", "deeeetails");
        ludnica.CloseProject();
        
        var doncho = new Developer(85012236461, "Doncho", "Donkov", 41500, Department.Production, web, ludnica);

        var kiro = new Manager(7511119253, "Kiro", "Pora", john, ivan, doncho);

        var listOfPeople = new List<IPerson> {kiro, doncho, ivan, john};

        foreach (var person in listOfPeople)
        {
            Console.WriteLine(person);
            Console.WriteLine("--------------------------------------------------------------------------------");   
        }
    }
}