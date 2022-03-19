using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CatWorx.BadgeMaker{

    class PeopleFetcher{

    public static List<Employee> GetEmployees(){
    List<Employee> employees = new List<Employee>();
      while(true) 
      {
        // Move the initial prompt inside the loop, so it repeats for each employee
        Console.WriteLine("Enter first name (leave empty to exit): ");

        // change input to firstName
        string firstName = Console.ReadLine();
        if (firstName == "") 
        {
          break;
        }

        // add a Console.ReadLine() for each value
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.Write("Enter Photo URL:");
        string photoUrl = Console.ReadLine();
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
        }

    return employees;
    }        

    public static List<Employee> GetFromAPI(){
        List<Employee> employees = new List<Employee>();

        //make the api call 
        using(WebClient client = new WebClient()){
            string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
            //allows us to parse the JSON from our api call 
            

            dynamic dynJson = JsonConvert.DeserializeObject(response);
            
            foreach (var item in dynJson.results)
            {
                string empId = item.id.value.ToString(); 
                empId = empId.Replace("-","");
                int empNum = Int32.Parse(empId);
                
                Employee emp = new Employee(
                    item.name.first.ToString(),
                    item.name.last.ToString(),
                    empNum,
                    item.picture.large.ToString()
                );
            employees.Add(emp);
            } 

            
            
        }


        return employees; 
    }

    }

}

