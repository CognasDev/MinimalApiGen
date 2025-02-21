using Dapper;
using MinimalApiGen.Framework.Collections;
using System.Data;
using static Dapper.SqlMapper;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed class IdsParameterFactory : IIdsParameterFactory
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public IParameter Create(IEnumerable<int> ids, string parameterName = "Ids")
    {
        if (!ids.Any())
        {
            throw new ArgumentOutOfRangeException(nameof(ids));
        }
        DataTable idsDataTable = CreateIdsDataTable();
        ids.FastForEach(id => idsDataTable.Rows.Add(id));
        ICustomQueryParameter tableValuedParameter = idsDataTable.AsTableValuedParameter();
        Parameter parameter = new(parameterName, tableValuedParameter);
        return parameter;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static DataTable CreateIdsDataTable()
    {
        DataTable idsDataTable = new();
        idsDataTable.Columns.Add("Id");
        return idsDataTable;
    }

    #endregion
}