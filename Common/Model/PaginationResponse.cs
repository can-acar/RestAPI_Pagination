using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// Pagination Response Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct PaginationResponse<T>
    {
        /// <summary>
        /// Array Of Requested Records Or Data
        /// </summary>
        public IList<T> Items;

        /// <summary>
        /// Total Number Of Records Found Against Requestee Search
        /// </summary>
        public int RecordsTotal;


    }
}
