using Moq;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Service.Interfaces;
using SignalRDemo.Service.Services;

namespace NunitTestProject1;

[TestFixture]
public class UnitTest
{
    [Test]
    public void TestGetSum()
    {
        int x = 9, y = 7;
        var result = GetSum(x, y);

        Assert.AreEqual(x + y, result);
        Assert.AreNotEqual(x - y, result);
    }

    private int GetSum(int x, int y)
    {
        return x + y;
    }

    [Test]
    public void TestStub()
    {
        // Arrange
        var productService = new StubProductService();

        // Act
        var product = productService.GetProductById(1);

        // Assert
        Assert.AreEqual("Stub Product", product.Name);
    }

    [Test]
    public void TestFake()
    {
        // Arrange
        var productService = new FakeProductService();

        // Act
        var product = productService.GetProductById(1);

        // Assert
        Assert.AreEqual("Fake Product 1", product.Name);
    }

    [Test]
    public void TestMock()
    {
        // Arrange
        var mockProductService = new Mock<ITestProductService>();
        mockProductService.Setup(s => s.GetProductById(1)).Returns(new Product { Id = 1, Name = "Mock Product", Price = 15.0m });

        // Act
        var product = mockProductService.Object.GetProductById(1);

        // Assert
        mockProductService.Verify(s => s.GetProductById(1), Times.Once);
        Assert.AreEqual("Mock Product", product.Name);
    }
}
