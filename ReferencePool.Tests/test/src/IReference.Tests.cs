namespace Tandbox.ReferencePool.Tests;

using Tandbox.ReferencePool;
using LightMock;
using LightMock.Generator;
using Shouldly;
using System;
using Xunit;

/// <summary>
/// Unit tests for the IReference interface using xUnit, LightMock, and Shouldly.
/// </summary>
public class IReferenceTests {
  private readonly Mock<IReference> _mockContext;
  private readonly IReference _mockReference;

  public IReferenceTests() {
    _mockContext = new Mock<IReference>();
    _mockReference = _mockContext.Object;
  }

  [Fact]
  public void Clear_ShouldBeCalledOnce() {
    // Arrange
    _mockContext.Arrange(m => m.Clear());

    // Act
    _mockReference.Clear();

    // Assert
    _mockContext.Assert(m => m.Clear(), Invoked.Once);
  }

  [Fact]
  public void Clear_ShouldNotThrowException() {
    // Arrange
    _mockContext.Arrange(m => m.Clear());

    // Act & Assert
    Should.NotThrow(() => _mockReference.Clear());
  }
}