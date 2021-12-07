
using System.Collections.Generic;
using System.Linq;

namespace EmployeeASAP.Data.Models.Seed
{
    public class SeedData
    {
       
        public static void SeedEmployeeData(EmployeeASAPContext context)
        {
            context.Database.EnsureCreated();

            var adresses = new List<Address>
            {
                new Address { Name = "Egypt"},
               new Address { Name = "USA"},
                new Address { Name = "Lebanon"},


            };

            if (!context.Address.Any())
            {
                context.AddRange(adresses);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employees = new List<Employee>
            {
                new Employee { FirstName = "Abdou", LastName = "Sameh",AddressId = adresses.FirstOrDefault().Id},
                new Employee { FirstName = "Ali",LastName = "Ahmed"  ,AddressId = adresses.FirstOrDefault().Id},
                new Employee { FirstName = "Ali",LastName = "Hassan" ,AddressId = adresses.FirstOrDefault().Id},


                new Employee { FirstName = "Ali",LastName = "Ayash",AddressId = adresses.Skip(1).FirstOrDefault().Id},
                new Employee { FirstName = "Mark",LastName = "Karam",AddressId = adresses.Skip(1).FirstOrDefault().Id},


                new Employee { FirstName = "Tony",LastName = "Mark",AddressId = adresses.Skip(2).FirstOrDefault().Id},
                new Employee { FirstName = "Amal" , LastName = "Magdy",AddressId = adresses.Skip(2).FirstOrDefault().Id},
               
            };
                context.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}
