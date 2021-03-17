using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IPaginationEntity<TPRESPONSE, TCOLUMNS>
    {
        Task<PaginationResponse<TPRESPONSE>> Get(PaginationRequest<TCOLUMNS> paginationRequest);
    }
}
