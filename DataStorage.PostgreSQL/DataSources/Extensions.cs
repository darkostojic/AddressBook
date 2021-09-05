using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources
{
    internal static class Extensions
    {
        internal static T GetRecord<T>(this IDataRecord record, string fieldName)
        {
            if (record.IsDBNull(record.GetOrdinal(fieldName))) return default(T);
            return (T)record[fieldName];
        }
    }
}
