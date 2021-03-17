using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestAPI_Pagination.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>'
    public class DataNamesMapper<TEntity> where TEntity : class, new()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>'
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>.Map(DataTable)'
        public IEnumerable<TEntity> Map(DataTable table)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>.Map(DataTable)'
        {
            //Step 1 - Get the Column Names
            var columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                                .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                                .ToList();

            //Step 3 - Map the data
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>.Map(DataRow)'
        public TEntity Map(DataRow row)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesMapper<TEntity>.Map(DataRow)'
        {
            //Step 1 - Get the Column Names
            var columnNames = row.Table.Columns
                                       .Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();

            //Step 3 - Map the data
            TEntity entity = new TEntity();
            foreach (var prop in properties)
            {
                PropertyMapHelper.Map(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }

    }
}