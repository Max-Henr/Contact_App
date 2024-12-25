using Business.Factories;
using Business.Models;

namespace Business.tests.Factories;

public class ContactFactory_Test
{
    [Fact]

    public void Create_ShouldReturnContact()
    {
        //Arrange

        //Act
        var result = ContactFactory.Create();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegForm>(result);
    }

}
