

using Business.Helpers;

namespace Business.tests.Helpers;

public class IdGenerator_Test
{
    [Fact]

    public void GenerateUniqueId_ShouldReturnString()
    {
        //Arrange

        //Act

        var result = IdGenerator.GenerateUniqueId();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<String>(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
