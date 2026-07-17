# DataFields

The **DataField Template** builds upon the Barebones Component by introducing configurable data.

Unlike the Barebones Component, this template stores actual data that can be changed from YAML without recompiling the game.

---

# Overview

A **DataField** allows YAML to override a Component's default value.

Without `[DataField]`, the value always remains whatever was written in C#.

Typical workflow:

```text
Create Component (.cs)
        ↓
Add a DataField
        ↓
Compile
        ↓
Reference the Component in YAML
        ↓
Override the default value (optional)
        ↓
Spawn an Entity
        ↓
Component now contains the final value
```

---

# Component Example

```csharp
namespace Content.Server._Starlight.LearningCSharp.Components;

/// <summary>
/// Demonstrates how DataFields allow Components to store configurable data.
/// </summary>
[RegisterComponent]
public sealed partial class DataFieldTemplateComponent : Component
{
    [DataField]
    public string Name = "Example";
}
```

---

# Namespace

```csharp
namespace Content.Server._Starlight.LearningCSharp.Components;
```

The namespace is the class's address.

It usually matches the folder structure and allows C# to organize code.

Other files locate this class through its namespace.

---

# RegisterComponent

```csharp
[RegisterComponent]
```

Registers this Component with the engine.

Without this attribute:

- The engine will not recognize the Component.
- YAML cannot use the Component.

---

# Class Declaration

```csharp
public sealed partial class DataFieldTemplateComponent : Component
```

## `public`

Allows other code to access this Component.

## `sealed`

Prevents other classes from inheriting from this one.

## `partial`

Allows this class to be split across multiple files.

## `class`

Defines a new class.

## `: Component`

Inherits from the engine's base `Component` class.

This tells the engine:

> "This class IS an ECS Component."

---

# DataField

```csharp
[DataField]
public string Name = "Example";
```

This is the first new concept introduced by this lesson.

`[DataField]` allows YAML to override the default value stored in C#.

Without `[DataField]`, the value will always remain `"Example"`.

---

# Breaking the Declaration Down

```csharp
public string Name = "Example";
```

| Part | Meaning |
|------|---------|
| `public` | Other code can access this variable. |
| `string` | The variable stores text. |
| `Name` | The variable's name. |
| `"Example"` | The variable's default value. |

---

# Common Field Types

## int

Stores whole numbers.

```csharp
[DataField]
public int Count = 5;
```

Examples:

- Health
- Ammo
- Charges
- Stack Size

---

## float

Stores decimal numbers.

Float values require the `f` suffix.

```csharp
[DataField]
public float Speed = 2.5f;
```

Examples:

- Speed
- Cooldowns
- Damage Multipliers

---

## string

Stores text.

```csharp
[DataField]
public string Name = "Example";
```

Examples:

- Character names
- Titles
- IDs
- Descriptions

---

## bool

Stores either `true` or `false`.

Think of it like a switch.

```text
ON / OFF

YES / NO

TRUE / FALSE
```

Example:

```csharp
[DataField]
public bool Enabled = true;
```

---

# YAML Override

Our Component contains:

```csharp
[DataField]
public string Name = "Example";
```

A YAML prototype can override this value.

```yml
components:
- type: DataFieldTemplate
  name: "Inanis' Talisman"
```

When the entity is spawned, the Component no longer contains:

```text
Example
```

Instead it contains:

```text
Inanis' Talisman
```

The default value has been overridden by YAML.

---

# Project Structure

SS14 separates C# code from YAML prototype files.

## C# Files

Components and Systems belong under `Content.Server`.

Typical location:

```text
Content.Server/
└── _Starlight/
    ├── Components/
    └── Systems/
```

Components store **data**.

Systems contain **logic**.

---

## YAML Prototype Files

Prototype (`.yml`) files do **not** belong inside `Content.Server`.

Instead they belong inside your project's Resources folder.

Typical location:

```text
Resources/
└── Prototypes/
    └── _Starlight/
```

(or another appropriate prototype folder.)

Prototype files are responsible for:

- Creating entities
- Adding Components
- Overriding `[DataField]` values
- Configuring default entity values

---

# Component vs Prototype

A Component does **not** create an entity.

A Prototype **creates** an entity and attaches Components to it.

Think of it like this:

```text
Component (.cs)
        │
        │ Defines data
        ▼
Prototype (.yml)
        │
        │ Creates an entity
        │ Adds Components
        │ Overrides DataFields
        ▼
Spawned Entity
```

For this lesson:

The Component contains:

```csharp
[DataField]
public string Name = "Example";
```

The Prototype overrides it:

```yml
components:
- type: DataFieldTemplate
  name: "Inanis' Talisman"
```

Result:

```text
Name = "Inanis' Talisman"
```

instead of:

```text
Name = "Example"
```

Remember:

- Components live in **C#**.
- Prototypes live in **YAML**.
- Components define what data exists.
- Prototypes decide which entities have that data and what the starting values should be.

---

# Testing

This template has been verified in-game.

The following workflow was tested successfully:

```text
Compile
        ↓
Component appears in VV
        ↓
Attach Component to an Entity
        ↓
Default value is visible
        ↓
Edit value in VV
        ↓
Override value through YAML
        ↓
Spawn Entity
        ↓
YAML value appears correctly
```

This confirms that:

- `[RegisterComponent]` registers the Component.
- `[DataField]` allows YAML to override default values.
- The engine stores the final configured value inside the Component.

---

# Summary

This lesson introduced the first configurable Component.

By completing this lesson you can now:

- Create a Component that stores configurable data.
- Understand how `[DataField]` works.
- Read and write a basic field declaration.
- Understand the difference between a variable's type and its name.
- Use `int`, `float`, `string`, and `bool` DataFields.
- Override C# default values from YAML.
- Verify Components using VV.
- Understand the relationship between Components and Prototypes.
- Know where Components, Systems, and YAML prototypes belong inside an SS14 project.
