using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.Person;
using System.Linq;

namespace PopulateBogusData
{
    public class CustomerData
    {

        public void Populate()
        {
            var fakeCustomer = new Faker<BusinessEntity.customer>("en")
            .StrictMode(false)

           .RuleFor(c => c.contactPerson, f => f.Name.FullName())
           .RuleFor(c => c.customerID, f => 0)
           .RuleFor(c => c.city, f => f.Address.City())
           .RuleFor(c => c.countryName, f => f.Address.Country())
           .RuleFor(c => c.countryId, f => f.Address.CountryCode())
           .RuleFor(c => c.region, f => f.Address.State())
           .RuleFor(c => c.phone, (f, c) => f.Phone.PhoneNumber("+# (###) ###-####"))
           .RuleFor(c => c.fax, (f, c) => f.Phone.PhoneNumber("+# (###) ###-####"))
           .RuleFor(c => c.balance, f => f.Random.Number(0, 100000000))
           ;


            List<BusinessEntity.customer> list = fakeCustomer.Generate(500000).ToList();

            BusinessEntity.CustomerDBEntities obj = new BusinessEntity.CustomerDBEntities();

            Console.WriteLine("records generated" + list.Count());

            obj.customers.AddRange(list);
            obj.SaveChanges();

            Console.WriteLine("Completed");

         


        }

    }
   

}
