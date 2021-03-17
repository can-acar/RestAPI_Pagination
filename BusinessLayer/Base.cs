using Common.Enum;
using Common.Interface;
using Common.Model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusinessLayer
{
    /// <summary>
    /// Provides grids filter's core functionality 
    /// </summary>
    public class Base<TDriveClassGrid, COLUMNS> : BaseLevel1
    {

        
        public string errorMessage;

        protected bool hasOrderByClause = false;            // flag for whether filter query has order clause 
        protected bool isAndPredicateAdded = false;         // flag for usage of Predicate variable  Expression<Func<TDriveClassGrid, bool>> andPredicate
        protected bool isOrPredicateAdded = false;          // flag for usage of Predicate variable  Expression<Func<TDriveClassGrid, bool>> orPredicate
        protected string searchColumnText { get; set; }            // temperary value holder during filter column iternation
        protected string genericSearchText { get; set; }            // temperary value holder filter generic search value
        


        protected Expression<Func<TDriveClassGrid, bool>> andPredicate      // predicate associated with AND conditions only 
#pragma warning disable CS0618 // 'PredicateBuilder.True<T>()' is obsolete: 'Use PredicateBuilder.New() instead.'
            = LinqKit.PredicateBuilder.True<TDriveClassGrid>();
#pragma warning restore CS0618 // 'PredicateBuilder.True<T>()' is obsolete: 'Use PredicateBuilder.New() instead.'
        protected Expression<Func<TDriveClassGrid, bool>> orPredicate       // predicate associated with OR conditions only
#pragma warning disable CS0618 // 'PredicateBuilder.False<T>()' is obsolete: 'Use PredicateBuilder.New() instead.'
            = LinqKit.PredicateBuilder.False<TDriveClassGrid>();
#pragma warning restore CS0618 // 'PredicateBuilder.False<T>()' is obsolete: 'Use PredicateBuilder.New() instead.'
        public IQueryable<TDriveClassGrid> records;                      // Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.

        public int totalRows;


        public Base(ICache _iCache) : base(_iCache)
        {
        }



        protected List<TDriveClassGrid> documentsGridRecords;




      


        /// <summary>
        /// Adjoin's specific filter column condition to predicate
        /// </summary>
        /// <typeparam name="U">Generic type parameter</typeparam>
        /// <param name="column">Instance of specific filter column ColumnParameterCollector object</param>
        /// <param name="columnFilterExpression">Specific filter column expression e.g x => x.StartWith("hasan")</param>
        /// <param name="genericFilterExpression">Generic filter coluumn expression it alway concerned with string only</param>
        /// <param name="orderExpression">It set's order by clause in the query</param>
        public void EvaluateFilter<U, COLUMNS>(PaginationRequest<COLUMNS> paginationRequest, ColumnParameter<COLUMNS> column,
           Expression<Func<TDriveClassGrid, bool>> columnFilterExpression,
           Expression<Func<TDriveClassGrid, bool>> genericFilterExpression,
           Expression<Func<TDriveClassGrid, U>> orderExpression
           )
        {
            // If this column enable to search
            //if (column.isColumnSearchable)
            {
                // If grid column header search has searchable value to build predicate for this column
                if (column.ColumnSearchText.Trim().Length != 0 && columnFilterExpression != null)
                {
                    andPredicate = andPredicate.And(columnFilterExpression);
                    isAndPredicateAdded = true;
                }
                else
                    // If grid generic search has searchable value to build predicate for this column
                    if (genericSearchText.Trim().Length != 0 && genericFilterExpression != null)
                {
                    orPredicate = orPredicate.Or(genericFilterExpression);
                    isOrPredicateAdded = true;
                }
            }

            // Set order by clause for this column
            OrderByField(paginationRequest, column, orderExpression);
        }



        /// <summary>
        /// Adjoin's specific filter column condition to predicate with comparision clause
        /// </summary>
        /// <typeparam name="U">Generic type paramete</typeparam>
        /// <param name="column">Instance of specific filter column ColumnParameterCollector object</param>
        /// <param name="searchColumnText">Specific column filter string value</param>
        /// <param name="fieldName">Specifix column name</param>
        /// <param name="orderExpression">It set's order by clause in the query</param>
        public void EvaluateNumericComparisonFilter<U>(PaginationRequest<COLUMNS> paginationRequest, ColumnParameter<COLUMNS> column,
          string searchColumnText,
          string fieldName,
          Expression<Func<TDriveClassGrid, U>> orderExpression
          )
        {
            // If this column enable to search
            //if (column.isColumnSearchable)
            {
                // If grid column header search has searchable value to build predicate for this column
                if (column.ColumnSearchText.Trim().Length != 0)
                {
                    // searchColumnText value shall be passed as ">=,100" or "<=,50" 
                    // for which it has to be split up
                    string[] str = searchColumnText.Split(',');
                    if (str.Length == 2)
                    {
                        string expression = str[0].Trim();          // hold's expression value such as ">=","=" and "<="
                        string strAmount = str[1].Trim();           // hold's numeric value
                        ParameterExpression paramExp = Expression.Parameter(typeof(string), fieldName);


                        if (IsNumber(strAmount))
                        {
                            decimal amount = decimal.Parse(strAmount);

                            PropertyInfo pi = typeof(TDriveClassGrid).GetProperty(fieldName);
                            ParameterExpression lnsParam = Expression.Parameter(typeof(TDriveClassGrid));
                            Expression left = Expression.Property(lnsParam, pi);
                            Expression right = Expression.Constant(Convert.ChangeType(amount, pi.PropertyType));
                            BinaryExpression binExp = null;


                            switch (expression)
                            {
                                // Construct expression for <= operator
                                case "<=":
                                    binExp = Expression.MakeBinary(ExpressionType.LessThanOrEqual, left, right);
                                    break;
                                // Construct expression for < operator
                                case "<":
                                    binExp = Expression.MakeBinary(ExpressionType.LessThan, left, right);
                                    break;
                                // Construct expression for = operator
                                case "=":
                                    binExp = Expression.MakeBinary(ExpressionType.Equal, left, right);
                                    break;
                                // Construct expression for >= operator
                                case ">=":
                                    binExp = Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, left, right);
                                    break;
                                // Construct expression for > operator
                                case ">":
                                    binExp = Expression.MakeBinary(ExpressionType.GreaterThan, left, right);
                                    break;
                            }
                            if (binExp != null)
                            {
                                // Construct lamda expression for predicate from previously constructed binExp and lnsParam
                                var theLambda = Expression.Lambda<Func<TDriveClassGrid, bool>>(binExp, lnsParam);
                                andPredicate = andPredicate.And(theLambda);
                                isAndPredicateAdded = true;
                            }
                            OrderByField(paginationRequest, column, orderExpression);
                        }
                    }
                }

            }

            // Set order by clause for this column
            OrderByField(paginationRequest, column, orderExpression);
        }



        /// <summary>
        /// Adjoin's specific column order by clause
        /// </summary>
        /// <typeparam name="U">Generic type paramete</typeparam>
        /// <param name="column">Instance of specific filter column ColumnParameterCollector object</param>
        /// <param name="orderExpression">It set's order by clause in the query</param>
        public void OrderByField<U, COLUMNS>(PaginationRequest<COLUMNS> paginationRequest, ColumnParameter<COLUMNS> column, Expression<Func<TDriveClassGrid, U>> orderExpression)
        {
            // If this column enable for order by clause
            if (paginationRequest.SortColumn.Equals(column.ColumnName))//  column.isColumnOrderable)
            {
                // If specific column order by clause is in ascending order
                if (paginationRequest.SortDirection == Common.Enum.OrderDirection.asc)
                {
                    if (records != null)
                    {
                        records = records.OrderBy(orderExpression);
                    }
                    hasOrderByClause = true;
                }
                else
                    // If specific column order by clause is in decending order
                    if (paginationRequest.SortDirection == Common.Enum.OrderDirection.desc)
                {
                    if (records != null)
                    {
                        records = records.OrderByDescending(orderExpression);
                    }
                    hasOrderByClause = true;
                }
            }
        }





        protected void EvaluateFilterForReport(Expression<Func<TDriveClassGrid, bool>> columnFilterExpression)
        {
            andPredicate = andPredicate.And(columnFilterExpression);
            isAndPredicateAdded = true;
        }


       

       



        /// <summary>
        /// It forge out predicate in IQueryable<TDriveClassGrid> records object
        /// </summary>
        /// <typeparam name="T">Derived class searchable grid associated object</typeparam>
        /// <param name="iBaseController">Interface of invoke class</param>
        /// <param name="gridParamCollet">GridParameterCollector object</param>
        /// <param name="defaultOrderExpression">Default order by clause expression if column level order is not set</param>
        /// <returns></returns>
        public async Task<List<TDriveClassGrid>> ForgeGridData<T, COLUMNS>(PaginationRequest<COLUMNS> paginationRequest, Expression<Func<TDriveClassGrid, T>> defaultOrderExpression)
        {



            // if order by clause is not set at column level
            if (!hasOrderByClause)
            {
                records = records.OrderBy(defaultOrderExpression);
            }

            // If andPreciate is enable
            if (isAndPredicateAdded)
            {
                records = records.AsExpandable().Where(andPredicate);
            }

            // If orPreciate is enable
            if (isOrPredicateAdded)
            {
                records = records.AsExpandable().Where(orPredicate);
            }

            IQueryable<TDriveClassGrid> countQuery = records;

            // Set t0tal numbers or rows comming under the query
            totalRows = countQuery.Count();

            if (paginationRequest.HasPagination)
            {
                int startIndex = ((paginationRequest.CurrentPage - 1) * paginationRequest.PageSize) == 0 ? 0 : ((paginationRequest.CurrentPage - 1) * paginationRequest.PageSize);
                // Slice required rows from pagination
                records = records.Skip(startIndex).Take(paginationRequest.PageSize);
            }




            return records.ToList();
        }



          protected void InitSorting(PaginationRequest<COLUMNS> paginationRequest)
        {

            


            PropertyInfo propInfo = typeof(TDriveClassGrid).GetProperty(paginationRequest.SortColumn.ToString());



            if (propInfo.PropertyType == typeof(double))
            {
                CompileSorting<double>(paginationRequest);
            }
            else
            if (propInfo.PropertyType == typeof(string))
            {
                CompileSorting<string>(paginationRequest);
            }
            else
            if (propInfo.PropertyType == typeof(decimal))
            {
                CompileSorting<decimal>(paginationRequest);
            }

        }


        protected void CompileSorting<T>(PaginationRequest<COLUMNS> paginationRequest)
        {
            var param = Expression.Parameter(typeof(TDriveClassGrid), "item");

            var sortExpression = Expression.Lambda<Func<TDriveClassGrid, T>>
                (Expression.Convert(Expression.Property(param, paginationRequest.SortColumn.ToString()), typeof(T)), param);


            if (paginationRequest.SortDirection == OrderDirection.asc)
            {
                hasOrderByClause = true;
                records = records.OrderBy(sortExpression);
            }
            else if (paginationRequest.SortDirection == OrderDirection.desc)
            {
                hasOrderByClause = true;
                records = records.OrderByDescending(sortExpression);
            }
        }





        /// <summary>
        /// Validate for numeric value
        /// </summary>
        /// <param name="value">string to be validated</param>
        /// <returns>Validaton result true or false</returns>
        public Boolean IsNumber(String value)
        {
            return Regex.IsMatch(value, @"^-?(([1-9]\d*)|0)(.0*[1-9](0*[1-9])*)?$");
        }


       



        public List<string> userIds = new List<string>();

       

        protected DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        protected DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }


        protected DateTime FirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        protected DateTime LastDayOfMonth(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }





        public DateTime GetCurrentDateTime()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
        }


        protected void CompileExceptionHandleMessage(Exception exp)
        {
            if( exp.InnerException != null )
            {
                errorMessage = exp.InnerException.Message;
            }
            else
            {
                errorMessage = exp.Message;
            }
             
        }

    }
}
