using MinimalApiGen.Generators.Abstractions.Common;
using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Generators.Abstractions.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetWithCache : IMapping, IPagination, IVersion, IQuery
{
}