using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Uniplac.Sindicontrata.WebApi.Common
{
    public class DataSourceResultWrapper
    {
        private DataSourceResultWrapper(DataSourceResult dataSourceResult)
        {
            if (dataSourceResult == null)
                dataSourceResult = new DataSourceResult();

            Results = dataSourceResult.Data;
            Total = dataSourceResult.Total;
            AggregateResults = dataSourceResult.AggregateResults;
            Errors = dataSourceResult.Errors;
        }

        public DataSourceResultWrapper(IEnumerable list, DataSourceRequest dataSourceRequest)
            : this(list.ToDataSourceResult(dataSourceRequest ?? new DataSourceRequest()))
        {
        }

        public DataSourceResultWrapper(DataTable dataTable, DataSourceRequest dataSourceRequest)
            : this(dataTable.WrapAsEnumerable().ToDataSourceResult(dataSourceRequest ?? new DataSourceRequest()))
        {
        }

        public IEnumerable Results { get; set; }
        public int Total { get; set; }
        public IEnumerable<AggregateResult> AggregateResults { get; set; }
        public object Errors { get; set; }

    }

    internal static class DataTableWrapperExtensions
    {
        internal static DataTableWrapper WrapAsEnumerable(this DataTable dataTable)
        {
            return new DataTableWrapper(dataTable);
        }

        internal static IEnumerable SerializeToDictionary(this IEnumerable enumerable, DataTable ownerDataTable)
        {
            if (enumerable is IEnumerable<AggregateFunctionsGroup> || enumerable is IEnumerable<IGroup>)
            {
                return enumerable.OfType<IGroup>()
                           .Select(group => SerializeGroupItem(ownerDataTable, group));
            }
            return enumerable.OfType<DataRowView>()
                       .Select(row =>
                       {
                           var result = new Dictionary<string, object>();
                           SerializeRow(ownerDataTable, row, result);
                           return result;
                       });
        }

        private static Dictionary<string, object> SerializeGroupItem(DataTable ownerDataTable, IGroup group)
        {
            var result = new Dictionary<string, object>
            { 
                { "Key", group.Key },
                { "HasSubgroups", group.HasSubgroups },
                { "Member", group.Member },
                { "Items", group.Items.SerializeToDictionary(ownerDataTable) }, 
                { "Subgroups", group.Subgroups.SerializeToDictionary(ownerDataTable) }
            };

            var aggregateGroup = group as AggregateFunctionsGroup;
            if (aggregateGroup != null)
            {
                result.Add("AggregateFunctionsProjection", aggregateGroup.AggregateFunctionsProjection);
                result.Add("Aggregates", aggregateGroup.Aggregates);
            }
            return result;
        }

        public static Dictionary<string, object> SerializeRow(this DataRowView row)
        {
            var table = row.DataView.Table;
            var result = new Dictionary<string, object>();
            SerializeRow(table, row, result);
            return result;
        }

        public static Dictionary<string, object> SerializeRow(this DataRow row)
        {
            var table = row.Table;
            return table.Columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => row.Field<object>(column.ColumnName));
        }

        private static void SerializeRow(DataTable dataTable, DataRowView row, Dictionary<string, object> owner)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                owner.Add(column.ColumnName, row.Row.Field<object>(column.ColumnName));
            }
        }
    }

    internal class DataTableWrapper : IEnumerable<DataRowView>
    {
        internal DataTableWrapper(DataTable dataTable)
        {
            Table = dataTable;
        }

        public DataTable Table { get; private set; }

        public IEnumerator<DataRowView> GetEnumerator()
        {
            if (Table == null)
                yield break;

            foreach (DataRowView row in Table.AsDataView())
            {
                yield return row;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}