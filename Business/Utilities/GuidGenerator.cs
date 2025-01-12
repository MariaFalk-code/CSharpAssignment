

namespace Business.Utilities;

/// <summary>
/// A utility class for generating GUIDs.
/// </summary>
public static class GuidGenerator
{
    public static string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }
}
