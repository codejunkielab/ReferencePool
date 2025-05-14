# ReferencePool

The `ReferencePool` class provides a mechanism for managing object pooling to reduce memory allocation and improve performance. It allows acquiring, releasing, adding, and removing references of specific types.

## Installation

Install the latest version of the [Tandbox.ReferencePool] package from nuget:

```sh
dotnet add package Tandbox.ReferencePool
```

## Features

- **Object Pooling**: Efficiently reuse objects to minimize memory allocation overhead.
- **Type-Specific Pools**: Manage pools for different types of objects.
- **Thread-Safe Operations**: Ensures safe access to the pool in multi-threaded environments.
- **Statistics Tracking**: Provides detailed information about the pool's usage, including counts for acquired, released, added, and removed references.

## Key Components

### `ReferencePool`
A static class that serves as the entry point for managing reference pools.

- **Acquire**: Retrieve an object from the pool.
- **Release**: Return an object to the pool after use.
- **Add**: Preload objects into the pool.
- **Remove**: Remove objects from the pool.
- **ClearAll**: Clear all reference pools.

### `ReferenceCollection`
An internal class that manages a specific type of reference.

- Tracks usage statistics such as:
  - Unused references
  - References in use
  - Total acquired, released, added, and removed references

### `ReferencePoolInformation`
A struct that provides detailed information about a specific reference pool.

- Includes properties for:
  - Reference type
  - Counts for unused, in-use, acquired, released, added, and removed references

## Usage

### Acquiring and Releasing References

```csharp
// Acquire a reference of type MyReference
var reference = ReferencePool.Acquire<MyReference>();

// Use the reference
reference.DoSomething();

// Release the reference back to the pool
ReferencePool.Release(reference);
```

# ReferencePool

The `ReferencePool` class provides a mechanism for managing object pooling to reduce memory allocation and improve performance. It allows acquiring, releasing, adding, and removing references of specific types.

## Features

- Efficiently manage object pooling to minimize memory allocation overhead.
- Support for acquiring and releasing references.
- Ability to add and remove references dynamically.
- Strict type checking for reference management.
- Detailed statistics for reference pool usage.

## Namespace

`Tandbox.ReferencePool`

## Key Classes and Interfaces

- **`ReferencePool`**: The main static class for managing reference pools.
- **`IReference`**: Interface that all pooled objects must implement.
- **`ReferencePoolInformation`**: Struct that provides detailed information about the state of a reference pool.

## How to Use

### 1. Implement the `IReference` Interface

All objects that will be managed by the `ReferencePool` must implement the `IReference` interface. This interface requires a `Clear` method to reset the object's state.

```csharp
public class MyReference : IReference {
    public int Value { get; set; }

    public void Clear() {
        Value = 0;
    }
}
