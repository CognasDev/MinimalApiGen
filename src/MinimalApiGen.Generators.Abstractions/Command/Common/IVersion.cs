﻿namespace MinimalApiGen.Generators.Abstractions.Command.Common;

/// <summary>
/// 
/// </summary>
public interface IVersion
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    ICommandOperations WithVersion(int version);

    #endregion
}