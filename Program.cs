using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
 class Program {

  static void Main(string[] args)
  {
    List<Employee> employees;
    Console.WriteLine("Would you like to use API data? If no, you will input your own data.");
    string useApi = Console.ReadLine();
    if (useApi == "yes"){
      employees = PeopleFetcher.GetFromAPI();
    }else{
      employees = PeopleFetcher.GetEmployees();
    }
    Util.PrintEmployees(employees);
    Util.MakeCSV(employees);
    Util.MakeBadges(employees);
  }
  }
}

