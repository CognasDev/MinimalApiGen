using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApiGen.Framework.Swagger;

/// <summary>
/// 
/// </summary>
public sealed class SwaggerSortedDocumentFilter : IDocumentFilter
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="swaggerDoc"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        OpenApiPaths sortedApiPaths = [];
        foreach (KeyValuePair<string, OpenApiPathItem> path in swaggerDoc.Paths)
        {
            OpenApiPathItem openApiPathItem = new(path.Value);
            openApiPathItem.Operations.Clear();
            foreach (KeyValuePair<OperationType, OpenApiOperation> operation in path.Value.Operations.OrderBy(operation => operation.Key.GetDisplayName()))
            {
                openApiPathItem.AddOperation(operation.Key, operation.Value);
            }
            sortedApiPaths.Add(path.Key, openApiPathItem);
        }
        swaggerDoc.Paths = sortedApiPaths;
    }

    #endregion
}