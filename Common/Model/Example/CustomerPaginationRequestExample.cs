using Common.Enum;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Example
{
    public class CustomerPaginationRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new PaginationRequest<CustomerPaginationGridColumns>()
            {
                CurrentPage = 1,
                HasPagination = true,
                PageSize = 10,
                SortColumn = CustomerPaginationGridColumns.ContactPerson,
                SortDirection = OrderDirection.asc,
                SearchText = "",

                Columns = new List<ColumnParameter<CustomerPaginationGridColumns>>()
                 {
                    new  ColumnParameter<CustomerPaginationGridColumns>()
                    {
                        ColumnName = CustomerPaginationGridColumns.Balance,
                        ColumnSearchText = "<=,500"
                    }
                 }
            };

        }
    }
}
