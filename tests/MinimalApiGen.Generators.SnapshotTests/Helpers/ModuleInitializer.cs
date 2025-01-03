﻿using System.Runtime.CompilerServices;

namespace MinimalApiGen.Generators.SnapshotTests.Helpers;

/// <summary>
/// 
/// </summary>
public static class ModuleInitializer
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [ModuleInitializer]
    public static void Init() => VerifySourceGenerators.Enable();

    #endregion
}