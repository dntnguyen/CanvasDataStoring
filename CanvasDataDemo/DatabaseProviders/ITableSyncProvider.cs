using CanvasDataDemo.Datas;
using System.Collections.Generic;

namespace CanvasDataDemo.DatabaseProviders
{
    public interface ITableSyncProvider
    {
        TableSync AddTableToTableSync(string tableNameToAdd, bool isIncremental);

        IEnumerable<TableSync> GetListTableSync();

        IEnumerable<TableSyncHistory> GetListTableSyncHistory();

        IEnumerable<TableSyncHistory> GetListTableSyncHistorySequence(string tableName);

        TableSync GetTableSync(string tableName);

    }
}