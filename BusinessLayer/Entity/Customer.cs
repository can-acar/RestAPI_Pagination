using Common.Enum;
using Common.Interface;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{


    public sealed class Customer : Base<CustomerPaginationModel, Common.Enum.CustomerPaginationGridColumns>, IPaginationEntity<CustomerPaginationModel, Common.Enum.CustomerPaginationGridColumns>
    {
        private Customer() : base(null)
        {

        }

        public Customer(ICache iCache) : base(iCache)
        {

        }






        public async Task<PaginationResponse<CustomerPaginationModel>> Get(PaginationRequest<Common.Enum.CustomerPaginationGridColumns> paginationRequest)
        {
            try
            {
                BusinessEntity.CustomerDBEntities obj = new BusinessEntity.CustomerDBEntities();

                records = (from cus in obj.customers.AsNoTracking()
                               // join count in obj.countries on cus.countryId equals count.countryId
                           select new CustomerPaginationModel
                           {
                               Id = cus.customerID,
                               ContactPerson = cus.contactPerson,
                               Phone = cus.phone,
                               Fax = cus.phone,
                               City = cus.city,
                               Region = cus.region,
                               Country = cus.countryName,
                               CountryId = cus.countryId,
                               Balance = cus.balance
                           }).AsQueryable();



                if (paginationRequest.SortColumn != CustomerPaginationGridColumns.None)
                {
                    InitSorting(paginationRequest);
                }
                else
                {
                    paginationRequest.SortColumn = CustomerPaginationGridColumns.Id;
                    InitSorting(paginationRequest);
                }


                genericSearchText = paginationRequest.SearchText == null ? null : paginationRequest.SearchText.Trim();      // set generic search value

                ColumnParameter<Common.Enum.CustomerPaginationGridColumns> column = new ColumnParameter<CustomerPaginationGridColumns>() { };



                // Iterate through filter grid column to consturct query predicate
                //foreach (ColumnParameter<Common.Enum.CustomerPaginationGridColumns> column in paginationRequest.Columns)
                foreach (CustomerPaginationGridColumns columnParse in Enum.GetValues(typeof(CustomerPaginationGridColumns)))
                {
                   
                    if (!string.IsNullOrEmpty(genericSearchText))
                    {
                        // these is no specific column search
                        if (paginationRequest.Columns.Where(x => x.ColumnName == columnParse).Count() == 0)
                        {
                            column = new ColumnParameter<CustomerPaginationGridColumns>() { ColumnName = columnParse, ColumnSearchText = "" };
                        }
                        else
                        {
                            column = paginationRequest.Columns.Where(x => x.ColumnName == columnParse).FirstOrDefault();
                        }
                    }
                    else
                    {
                        column = paginationRequest.Columns.Where(x => x.ColumnName == columnParse).FirstOrDefault();
                    }

                    if (column == null)
                    {
                        continue;
                    }

                    searchColumnText = (column.ColumnSearchText ?? "").Trim();      // set current column search value


                    switch (column.ColumnName)
                    {
                        case Common.Enum.CustomerPaginationGridColumns.Balance:
                            EvaluateNumericComparisonFilter(paginationRequest, column,
                               searchColumnText,
                               "Balance",
                               x => x.Balance
                           );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.City:
                            EvaluateFilter(paginationRequest, column,
                                x => x.City.StartsWith(searchColumnText),
                                x => x.City.StartsWith(genericSearchText),
                                x => x.City
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.ContactPerson:
                            EvaluateFilter(paginationRequest, column,
                                x => x.ContactPerson.StartsWith(searchColumnText),
                                x => x.ContactPerson.StartsWith(genericSearchText),
                                x => x.ContactPerson
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.Country:
                            EvaluateFilter(paginationRequest, column,
                                x => x.Country.StartsWith(searchColumnText),
                                x => x.Country.StartsWith(genericSearchText),
                                x => x.Country
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.CountryId:
                            if (!IsNumber(searchColumnText))
                            {
                                continue;
                            }

                            string type = searchColumnText;

                            EvaluateFilter(paginationRequest, column,
                                x => x.CountryId == type,
                                null,
                                x => x.CountryId
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.Fax:
                            EvaluateFilter(paginationRequest, column,
                                x => x.Fax.StartsWith(searchColumnText),
                                x => x.Fax.StartsWith(genericSearchText),
                                x => x.Fax
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.Phone:
                            EvaluateFilter(paginationRequest, column,
                                x => x.Phone.StartsWith(searchColumnText),
                                x => x.Phone.StartsWith(genericSearchText),
                                x => x.Phone
                                );
                            break;
                        case Common.Enum.CustomerPaginationGridColumns.Region:
                            EvaluateFilter(paginationRequest, column,
                                x => x.Region.StartsWith(searchColumnText),
                                x => x.Region.StartsWith(genericSearchText),
                                x => x.Region
                                );
                            break;
                    }
                }

                PaginationResponse<CustomerPaginationModel> response = new PaginationResponse<CustomerPaginationModel>();

                IQueryable<CustomerPaginationModel> countQuery = records;
                response.Items = ForgeGridData(paginationRequest, x => x.ContactPerson).Result;
                response.RecordsTotal = totalRows;

                // Generating data
                return response;
            }
            catch (Exception exp)
            {
                CompileExceptionHandleMessage(exp);
                return new PaginationResponse<CustomerPaginationModel>() { Items = null };
            }
            finally
            {
                records = null;
            }
        }
    }

}
