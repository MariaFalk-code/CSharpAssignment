

using Business.Utilities;

namespace Tests.Utilities;

public class GuidGenerator_Tests
{
    [Fact]
    public void GenerateGuid_ReturnsValidGuid()
    {
        // Arrange
        var guid = GuidGenerator.GenerateGuid();

        // Act
        var isValidGuid = Guid.TryParse(guid, out _);

        // Assert
        Assert.True(isValidGuid, "GenerateGuid did not return a valid GUID.");
    }

    [Fact]
    public void GenerateGuid_ReturnsUniqueGuids()
    {
        // Arrange
        var guid1 = GuidGenerator.GenerateGuid();
        var guid2 = GuidGenerator.GenerateGuid();
        // Act
        var areGuidsUnique = guid1 != guid2;
        // Assert
        Assert.True(areGuidsUnique, "GenerateGuid did not return unique GUIDs.");
    }
}
