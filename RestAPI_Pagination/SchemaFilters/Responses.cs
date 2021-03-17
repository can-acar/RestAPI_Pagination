﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swashbuckle.Swagger;

namespace RestAPI_Pagination.SchemaFilters
{
  
    /// <summary>
    /// This represents the schema filter entity for the response model classes.
    /// </summary>
    public class Responses : ISchemaFilter
    {
        private readonly IEnumerable<Type> _types;

        /// <summary>
        /// Initializes a new instance of the <see cref="Responses"/> class.
        /// </summary>
        /// <param name="types">List of types to consider in XML request payload.</param>
        public Responses(params Type[] types)
        {
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            this._types = types;
        }

        /// <inheritdoc />
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (!this._types.Contains(type))
            {
                return;
            }

            schema.xml = new Xml() { name = "response" };
        }
    }

}