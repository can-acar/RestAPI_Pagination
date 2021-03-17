using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestAPI_Pagination.Models;

namespace RestAPI_Pagination.HelperMethods
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AttributeHelper'
    public static class AttributeHelper
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AttributeHelper'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AttributeHelper.GetDataNames(Type, string)'
        public static List<string> GetDataNames(Type type, string propertyName)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AttributeHelper.GetDataNames(Type, string)'
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "DataNamesAttribute").FirstOrDefault();
            if (property != null)
            {
                return ((DataNamesAttribute)property).ValueNames;
            }
            return new List<string>();
        }
    }
}