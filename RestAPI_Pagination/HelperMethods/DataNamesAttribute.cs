using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI_Pagination.Models
{
    [AttributeUsage(AttributeTargets.Property)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute'
    public class DataNamesAttribute : Attribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute._valueNames'
        protected List<string> _valueNames { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute._valueNames'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.ValueNames'
        public List<string> ValueNames
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.ValueNames'
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.DataNamesAttribute()'
        public DataNamesAttribute()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.DataNamesAttribute()'
        {
            _valueNames = new List<string>();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.DataNamesAttribute(params string[])'
        public DataNamesAttribute(params string[] valueNames)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DataNamesAttribute.DataNamesAttribute(params string[])'
        {
            _valueNames = valueNames.ToList();
        }
    }
}