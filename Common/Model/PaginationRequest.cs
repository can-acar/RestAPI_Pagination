using Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    /// <summary>
    /// Generic pagination Reqeust Model
    /// </summary>
    public class PaginationRequest<T>
    {
        /// <summary>
        /// Page number From Which Requestee Wants To Start Its Pagination
        /// </summary>
        [Required]
        [Range(typeof(int), "1", "200000")]
        [DefaultValue(1)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// Requestee Prefered Page Size
        /// </summary>
        [Required]
        [DefaultValue(11)]
        public int PageSize { get; set; }

        /// <summary>
        /// Generic Search Means search Through All Visible Columns
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Name Of The Column With Which Requestee Wants To Order By
        /// </summary>
        public T SortColumn { get; set; }

        /// <summary>
        /// Direction Of Order By Columns "desc" For Descending And "asc" For Ascending
        /// </summary>
        [Required]
        public OrderDirection SortDirection { get; set; }


        /// <summary>
        /// To return records with pagination this property has to be true, by default its false
        /// </summary>
        [DefaultValue(true)]
        public bool HasPagination { get; set; }


        /// <summary>
        /// These Are The List Of Filters On Specific Columns
        /// </summary>
        public List<ColumnParameter<T>> Columns { get; set; }
    }

    /// <summary>
    /// These Are The List Of Filters On Specific Columns
    /// </summary>
    public class ColumnParameter<T>
    {
        [Required]
        public T ColumnName { get; set; }

        [Required]
        public string ColumnSearchText { get; set; }
    }
}
