namespace CodeJunkie.ReferencePool.Tests;

using CodeJunkie.ReferencePool;
using LightMock;
using LightMock.Generator;
using Shouldly;
using System;
using Xunit;

public class ReferencePoolTests {
  private readonly Mock<IReference> _mockContext;
  private readonly IReference _mockReference;

  public ReferencePoolTests() {
    _mockContext = new Mock<IReference>();
    _mockReference = _mockContext.Object;
  }

  [Fact]
  public void Acquire_ShouldReturnNewReference_WhenPoolIsEmpty() {
    // Arrange
    ReferencePool.ClearAll();

    // Act
    var reference = ReferencePool.Acquire<MockReference>();

    // Assert
    reference.ShouldNotBeNull();
    reference.ShouldBeOfType<MockReference>();
  }

  [Fact]
  public void Release_ShouldAddReferenceBackToPool() {
    // Arrange
    ReferencePool.ClearAll();
    var reference = ReferencePool.Acquire<MockReference>();

    // Act
    ReferencePool.Release(reference);

    // Assert
    var poolInfo = ReferencePool.GetAllReferencePoolInfos();
    poolInfo.Length.ShouldBe(1);
    poolInfo[0].UnusedReferenceCount.ShouldBe(1);
  }

  [Fact]
  public void Add_ShouldIncreasePoolSize() {
    // Arrange
    ReferencePool.ClearAll();

    // Act
    ReferencePool.Add<MockReference>(5);

    // Assert
    var poolInfo = ReferencePool.GetAllReferencePoolInfos();
    poolInfo.Length.ShouldBe(1);
    poolInfo[0].UnusedReferenceCount.ShouldBe(5);
  }

  [Fact]
  public void Remove_ShouldDecreasePoolSize() {
    // Arrange
    ReferencePool.ClearAll();
    ReferencePool.Add<MockReference>(5);

    // Act
    ReferencePool.Remove<MockReference>(3);

    // Assert
    var poolInfo = ReferencePool.GetAllReferencePoolInfos();
    poolInfo.Length.ShouldBe(1);
    poolInfo[0].UnusedReferenceCount.ShouldBe(2);
  }

  [Fact]
  public void RemoveAll_ShouldClearPool() {
    // Arrange
    ReferencePool.ClearAll();
    ReferencePool.Add<MockReference>(5);

    // Act
    ReferencePool.RemoveAll<MockReference>();

    // Assert
    var poolInfo = ReferencePool.GetAllReferencePoolInfos();
    foreach (var info in poolInfo) {
      info.UnusedReferenceCount.ShouldBe(0);
      info.UsingReferenceCount.ShouldBe(0);
    }
  }

  private sealed class MockReference : IReference {
    public void Clear() {
      // Mock implementation of Clear
    }
  }
}
