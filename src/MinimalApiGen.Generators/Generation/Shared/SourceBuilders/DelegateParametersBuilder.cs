using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class DelegateParametersBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessLogicParameters"></param>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    /// <param name="modelIdPropertyType"></param>
    /// <returns></returns>
    internal static string BuildForId(EquatableArray<BusinessLogicParamterResult> businessLogicParameters,
                                      EquatableArray<string> services,
                                      EquatableDictionary<string, string> keyedServices,
                                      string modelIdPropertyType)
    {
        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<string> businessLogicParametersSpan = businessLogicParameters.Select(param => param.Type).ToArray();
        StringBuilder stringBuilder = new();

        foreach (string parameter in businessLogicParametersSpan)
        {
            if (services.Contains(parameter))
            {
                string serviceName = parameter.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameter) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameter == modelIdPropertyType)
            {
                stringBuilder.Append("id, ");
            }
            else if (parameter == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessLogicParameters"></param>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    /// <param name="modelName"></param>
    /// <returns></returns>
    internal static string BuildForModel(EquatableArray<BusinessLogicParamterResult> businessLogicParameters,
                                         EquatableArray<string> services,
                                         EquatableDictionary<string, string> keyedServices,
                                         string modelName)
    {
        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<string> businessLogicParametersSpan = businessLogicParameters.Select(param => param.Type).ToArray();
        StringBuilder stringBuilder = new();

        foreach (string parameter in businessLogicParametersSpan)
        {
            if (services.Contains(parameter))
            {
                string serviceName = parameter.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameter) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameter == modelName)
            {
                stringBuilder.Append("model, ");
            }
            else if (parameter == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessLogicParameters"></param>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    /// <param name="queryParameters"></param>
    /// <returns></returns>
    internal static string Build(EquatableArray<BusinessLogicParamterResult> businessLogicParameters,
                                 EquatableArray<string> services,
                                 EquatableDictionary<string, string> keyedServices,
                                 EquatableArray<QueryParameterResult> queryParameters)
    {
        if (businessLogicParameters.Count == 0)
        {
            return string.Empty;
        }

        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<BusinessLogicParamterResult> businessLogicParametersSpan = businessLogicParameters.AsSpan();
        StringBuilder stringBuilder = new();

        foreach (BusinessLogicParamterResult parameter in businessLogicParametersSpan)
        {
            string parameterType = parameter.Type;
            if (queryParameters.SingleOrDefault(queryParameter => queryParameter.Name == parameter.Name) is QueryParameterResult queryParameterResult)
            {
                stringBuilder.Append(queryParameterResult.Name);
                stringBuilder.Append(", ");
            }
            else if (services.Contains(parameterType))
            {
                string serviceName = parameterType.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameterType) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameterType == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    #endregion
}