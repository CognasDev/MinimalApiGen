namespace MinimalApiGen.Framework.Services;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public sealed class LocationResponse<TResponse> where TResponse : class
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public TResponse? Response { get; }

    /// <summary>
    /// 
    /// </summary>
    public Uri? Location { get; }

    /// <summary>
    /// 
    /// </summary>
    public int? Id { get; }

    /// <summary>
    /// 
    /// </summary>
    public bool Success { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="LocationResponse{TResponse}"/>
    /// </summary>
    /// <param name="response"></param>
    /// <param name="location"></param>
    public LocationResponse(TResponse? response, Uri? location)
    {
        Response = response;
        Location = location;

        if (Location is not null)
        {
            string absolutePath = Location.AbsolutePath;
            int index = absolutePath.LastIndexOf('/') + 1;
            Id = int.Parse(absolutePath[index..]);
            Success = true;
        }
    }

    #endregion
}