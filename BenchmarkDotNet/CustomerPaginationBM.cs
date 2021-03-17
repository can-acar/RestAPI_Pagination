using BenchmarkDotNet.Attributes;
using Common.Enum;
using Common.Interface;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BenchmarkDotNet
{
    //[ClrJob(baseline: true), CoreJob, CoreRtJob]
    //[InProcess]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(printAsm: true, printDiff: true)]
    [RPlotExporter,RankColumn]
    public class CustomerPaginationBM : BaseBM
    {


        protected const string balanceFilterHigherLimit = ">=,50000";
        protected const string balanceFilterLowerLimit = "<=,50000";
        protected const string contactPersonFilter = "Ali";
        protected const string countyryFilter = "UK";
        protected const string phoneFilter = "(0800)";



        //[Benchmark( Baseline = true)]
        [Benchmark(OperationsPerInvoke = 10_000, Baseline = true) ]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Id,CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Id,CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Id,CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Id,CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Id, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Id, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Id, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Id, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Id, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.None, null)]
        [Arguments(20,80, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        [Arguments(50,200, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]

        [Arguments(10, 300, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.ContactPerson, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Phone, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Fax, CustomerPaginationGridColumns.Phone, phoneFilter)]


        ////[Arguments(20, 80, CustomerPaginationGridColumns.Email)]
        ////[Arguments(50,200, CustomerPaginationGridColumns.Email)]
        ////[Arguments(20, 80, CustomerPaginationGridColumns.Email)]
        ////[Arguments(20, 80, CustomerPaginationGridColumns.Email)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.City, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Region, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Country, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.CountryId, CustomerPaginationGridColumns.Phone, phoneFilter)]

        //[Arguments(20, 80, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.None, null)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.None, null)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.None, null)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.Balance, balanceFilterHigherLimit)]
        //[Arguments(50, 200, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.Balance, balanceFilterLowerLimit)]
        //[Arguments(10, 300, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.ContactPerson, contactPersonFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.Country, countyryFilter)]
        //[Arguments(20, 80, CustomerPaginationGridColumns.Balance, CustomerPaginationGridColumns.Phone, phoneFilter)]
        public void GetCustomerPage(int currentPage, int pageSize, CustomerPaginationGridColumns sortColumn, CustomerPaginationGridColumns filterColumn, string filterText)
        {
           

            ColumnParameter<CustomerPaginationGridColumns> filter = null;

            if(CustomerPaginationGridColumns.None != filterColumn)
            {
                filter = new ColumnParameter<CustomerPaginationGridColumns>() { ColumnName = filterColumn, ColumnSearchText = filterText.ToString() };
            }


            PaginationRequest<CustomerPaginationGridColumns> request = new PaginationRequest<CustomerPaginationGridColumns>()
            {
                CurrentPage = currentPage,
                HasPagination = true,
                PageSize = pageSize,
                SortColumn = sortColumn ,
                SortDirection = OrderDirection.asc,
                SearchText = null,

                Columns = new List<ColumnParameter<CustomerPaginationGridColumns>>()
                 {
                    filter
                 }
            };


            BusinessLayer.Entity.Customer obj = new BusinessLayer.Entity.Customer(this);
            PaginationResponse<CustomerPaginationModel> response = obj.Get(request).Result;
        }
    }
}
