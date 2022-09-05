using CanvasDataDemo.Models;
using System.Data;

namespace CanvasDataDemo.DatabaseProviders
{
    public interface IBaseProvider
    {
        ResponseResult InsertDataToTable(TableSchema tableSchema, TableFileHistory tableFileHistory, DataTable dtData, int? latestSequence = null);
        void SetQueryTimeout(int seconds);
    }
}