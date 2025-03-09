using Dapper;
using MinimalApiGen.Shared.Collections;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed class DynamicParameterFactory : IDynamicParameterFactory
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public DynamicParameters? Create(IReadOnlyList<IParameter> parameters)
    {
        int parameterCount = parameters.Count;
        if (parameterCount == 1)
        {
            DynamicParameters singleDynamicParameter = new();
            IParameter parameter = parameters[0];
            singleDynamicParameter.Add(parameter.Name, parameter.Value);
            return singleDynamicParameter;
        }
        else if (parameterCount > 1)
        {
            DynamicParameters multipleDynamicParameters = new();
            parameters.FastForEach(parameter => multipleDynamicParameters.Add(parameter.Name, parameter.Value));
            return multipleDynamicParameters;
        }
        return null;
    }

    #endregion
}