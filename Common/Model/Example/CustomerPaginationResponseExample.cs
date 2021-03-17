using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Example
{
    public class CustomerPaginationResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {


            return new PaginationResponse<CustomerPaginationModel>()
            {

                Items = new List<CustomerPaginationModel>()
               {
                   new CustomerPaginationModel() {
                    Id =  558706,
                    ContactPerson= "Kaden Goyette",
                    Phone= "+0 (000) 006-1218",
                    Fax= "+0 (000) 006-1218",
                    City= "Dayneshire",
                    Region= "New Mexico",
                    Country= "Zimbabwe",
                    CountryId= "KM",
                    Balance=42746375
                   },
                    new CustomerPaginationModel()
          {
              Id = 3084,
              ContactPerson = "Camron Murphy",
              Phone = "+0 (000) 014-6337",
              Fax = "+0 (000) 014-6337",
              City = "West Makaylamouth",
              Region = "Rhode Island",
              Country = "Eritrea",
              CountryId = "SL",
              Balance = 90749651
          },
                    new CustomerPaginationModel()
            {
                Id = 344243.0,
                ContactPerson = "Edmund Kunde",
                Phone = "+0 (000) 020-0348",
                Fax = "+0 (000) 020-0348",
                City = "South Veda",
                Region = "Connecticut",
                Country = "Namibia",
                CountryId = "NI",
                Balance = 9857538
            },
            new CustomerPaginationModel()
            {
                Id = 100942.0,
                ContactPerson = "Gregoria Weber",
                Phone = "+0 (000) 023-9359",
                Fax = "+0 (000) 023-9359",
                City = "North Feliciamouth",
                Region = "Arkansas",
                Country = "Saint Vincent and the Grenadines",
                CountryId = "VC",
                Balance = 93437953
            },
            new CustomerPaginationModel()
            {
                Id = 718378.0,
                ContactPerson = "Liana Braun",
                Phone = "+0 (000) 034-7660",
                Fax = "+0 (000) 034-7660",
                City = "West Carmen",
                Region = "Louisiana",
                Country = "Argentina",
                CountryId = "GN",
                Balance = 6048061
            },
            new CustomerPaginationModel()
            {
                Id = 992587.0,
                ContactPerson = "Roselyn Gusikowski",
                Phone = "+0 (000) 060-3298",
                Fax = "+0 (000) 060-3298",
                City = "North Deborahview",
                Region = "Wyoming",
                Country = "Northern Mariana Islands",
                CountryId = "ZW",
                Balance = 88993087
            },
            new CustomerPaginationModel()
            {
                Id = 520955.0,
                ContactPerson = "Justice Simonis",
                Phone = "+0 (000) 062-3559",
                Fax = "+0 (000) 062-3559",
                City = "Westville",
                Region = "Nevada",
                Country = "Rwanda",
                CountryId = "AQ",
                Balance = 13154693
            },
            new CustomerPaginationModel()
            {
                Id = 107097.0,
                ContactPerson = "Favian Champlin",
                Phone = "+0 (000) 071-7798",
                Fax = "+0 (000) 071-7798",
                City = "South Elmore",
                Region = "California",
                Country = "Italy",
                CountryId = "HM",
                Balance = 20676921
            },
            new CustomerPaginationModel()
            {
                Id = 440620.0,
                ContactPerson = "Brayan Kertzmann",
                Phone = "+0 (000) 090-1547",
                Fax = "+0 (000) 090-1547",
                City = "East Zander",
                Region = "Alaska",
                Country = "Cape Verde",
                CountryId = "EG",
                Balance = 4399867
            },
            new CustomerPaginationModel()
            {
                Id = 696499.0,
                ContactPerson = "Elaina Hansen",
                Phone = "+0 (000) 093-6889",
                Fax = "+0 (000) 093-6889",
                City = "South Minnieland",
                Region = "Oklahoma",
                Country = "Jamaica",
                CountryId = "TN",
                Balance = 84783707
            }


                },
                RecordsTotal = 999955
            };

        }
    }
}


