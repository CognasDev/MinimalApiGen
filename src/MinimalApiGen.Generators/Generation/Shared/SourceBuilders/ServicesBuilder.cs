using MinimalApiGen.Generators.Equality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
public sealed class ServicesBuilder
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Services { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ServicesSummary { get; }

    /// <summary>
    /// 
    /// </summary>
    public string FromServices { get; }

    /// <summary>
    /// 
    /// </summary>
    public string FromKeyedServices { get; }

    /// <summary>
    /// 
    /// </summary>
    public string ServiceNames { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    public ServicesBuilder(EquatableArray<string> services, EquatableDictionary<string, string> keyedServices)
    {
        ReadOnlySpan<string> servicesSpan = services.AsSpan();
        ReadOnlySpan<string> serviceCamelCaseNames = InitiateServiceCamelCaseNames(servicesSpan);
        ReadOnlySpan<string> keyedServiceCamelCaseNames = InitiateKeyedServiceCamelCaseNames(keyedServices.KeysAsSpan());
        Services = BuildServices(keyedServices.ValuesAsSpan(), servicesSpan, serviceCamelCaseNames, keyedServiceCamelCaseNames);
        ServicesSummary = BuildServicesSummary(serviceCamelCaseNames, keyedServiceCamelCaseNames);
        FromServices = BuildFromServices(servicesSpan, serviceCamelCaseNames);
        FromKeyedServices = BuildFromKeyedServices(keyedServices, keyedServiceCamelCaseNames);
        ServiceNames = BuildServiceNames(serviceCamelCaseNames, keyedServiceCamelCaseNames);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    private ReadOnlySpan<string> InitiateServiceCamelCaseNames(ReadOnlySpan<string> servicesSpan)
    {
        List<string> camelCaseNames = new(servicesSpan.Length);
        foreach (string service in servicesSpan)
        {
            string serviceName = service.Split('.').Last();
            string camelCaseName = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
            camelCaseNames.Add(camelCaseName);
        }
        return new ReadOnlySpan<string>([.. camelCaseNames]);
    }

    /// <summary>
    /// 
    /// </summary>
    private ReadOnlySpan<string> InitiateKeyedServiceCamelCaseNames(ReadOnlySpan<string> keyedServiceKeys)
    {
        List<string> camelCaseNames = new(keyedServiceKeys.Length);
        foreach (string key in keyedServiceKeys)
        {
            string camelCaseName = JsonNamingPolicy.CamelCase.ConvertName(key);
            camelCaseNames.Add(camelCaseName);
        }
        return new ReadOnlySpan<string>([.. camelCaseNames]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyedServiceTypes"></param>
    /// <param name="servicesSpan"></param>
    /// <param name="serviceCamelCaseNames"></param>
    /// <param name="keyedServiceCamelCaseNames"></param>
    /// <returns></returns>
    private string BuildServices(ReadOnlySpan<string> keyedServiceTypes,
                                 ReadOnlySpan<string> servicesSpan,
                                 ReadOnlySpan<string> serviceCamelCaseNames,
                                 ReadOnlySpan<string> keyedServiceCamelCaseNames)
    {
        StringBuilder builder = new();
        for (int i = 0; i < servicesSpan.Length; i++)
        {
            builder.Append("\t\t");
            builder.Append(servicesSpan[i]);
            builder.Append(" ");
            builder.Append(serviceCamelCaseNames[i]);
            builder.AppendLine(",");
        }
        for (int i = 0; i < keyedServiceTypes.Length; i++)
        {
            builder.Append("\t\t");
            builder.Append(keyedServiceTypes[i]);
            builder.Append(" ");
            builder.Append(keyedServiceCamelCaseNames[i]);
            builder.AppendLine(",");
        }
        builder.Append("\t\t");
        string servicesString = builder.ToString();
        return servicesString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCamelCaseNames"></param>
    /// <param name="keyedServiceCamelCaseNames"></param>
    /// <returns></returns>
    private string BuildServicesSummary(ReadOnlySpan<string> serviceCamelCaseNames, ReadOnlySpan<string> keyedServiceCamelCaseNames)
    {
        StringBuilder builder = new();
        foreach (string name in serviceCamelCaseNames)
        {
            builder.Append("\t/// <param name=\"");
            builder.Append(name);
            builder.AppendLine("\"></param>");
        }
        foreach (string name in keyedServiceCamelCaseNames)
        {
            builder.Append("\t/// <param name=\"");
            builder.Append(name);
            builder.AppendLine("\"></param>");
        }
        builder.Append("\t");
        string servicesString = builder.ToString();
        return servicesString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="servicesSpan"></param>
    /// <param name="serviceCamelCaseNames"></param>
    /// <returns></returns>
    private string BuildFromServices(ReadOnlySpan<string> servicesSpan, ReadOnlySpan<string> serviceCamelCaseNames)
    {
        StringBuilder builder = new();
        for (int i = 0; i < servicesSpan.Length; i++)
        {
            builder.AppendLine(",");
            builder.Append("\t\t\t\t");
            builder.Append("[FromServices] ");
            builder.Append(servicesSpan[i]);
            builder.Append(" ");
            builder.Append(serviceCamelCaseNames[i]);
        }
        string servicesString = builder.ToString();
        return servicesString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyedServices"></param>
    /// <param name="keyedServiceCamelCaseNames"></param>
    /// <returns></returns>
    private string BuildFromKeyedServices(EquatableDictionary<string, string> keyedServices, ReadOnlySpan<string> keyedServiceCamelCaseNames)
    {
        StringBuilder builder = new();
        int index = 0;
        foreach (KeyValuePair<string, string> keyValuePair in keyedServices)
        {
            builder.AppendLine(",");
            builder.Append("\t\t\t\t");
            builder.Append("[FromKeyedServices(\"");
            builder.Append(keyValuePair.Key);
            builder.Append("\")] ");
            builder.Append(keyValuePair.Value);
            builder.Append(" ");
            builder.Append(keyedServiceCamelCaseNames[index++]);
        }
        string servicesString = builder.ToString();
        return servicesString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string BuildServiceNames(ReadOnlySpan<string> serviceCamelCaseNames, ReadOnlySpan<string> keyedServiceCamelCaseNames)
    {
        StringBuilder builder = new();
        foreach (string name in serviceCamelCaseNames)
        {
            builder.Append(name);
            builder.Append(", ");
        }
        foreach (string name in keyedServiceCamelCaseNames)
        {
            builder.Append(name);
            builder.Append(", ");
        }
        string servicesString = builder.ToString();
        return servicesString;
    }

    #endregion
}