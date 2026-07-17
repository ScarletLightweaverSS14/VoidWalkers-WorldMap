# SS14 C# Learning Templates

A collection of documented C# examples and templates for learning the Space Station 14 (SS14) Entity Component System (ECS).

This repository is intended for beginners who want to understand **how SS14 code works**, not just copy and paste snippets.

Every example focuses on explaining **why** something exists, how it interacts with the engine, and how the different parts fit together.

---

# What is this?

This project contains:

- Barebones Components
- DataField examples
- Partial Class examples
- System templates
- Event examples
- TryComp examples
- Dependency Injection examples
- Documentation explaining every concept

The goal is to bridge the gap between:

> "I can read C#"

and

> "I understand how SS14 is structured."

---

# Philosophy

Instead of large tutorials, this repository is built around small, focused examples.

Each file introduces a single concept and is heavily documented.

Examples are intended to be read in order.

---

# Learning Path

## Components

### Lesson 1 - Barebones Component

Learn:

- Component structure
- `namespace`
- `public`
- `sealed`
- `partial`
- `class`
- `: Component`
- `[RegisterComponent]`
- Component naming rules

---

### Lesson 2 - DataFields

Learn:

- `[DataField]`
- YAML overrides
- `int`
- `float`
- `bool`
- `string`
- Access modifiers
- Attributes
- Reading a field declaration
- Variables and default values

---

### Lesson 3 - Partial Classes

Learn:

- Why `partial` exists
- Upstream vs downstream workflow
- Extending Components without modifying upstream
- How the compiler merges partial classes
- Common mistakes

---

### Planned Component Lessons

- Common Attributes
- Reading C# Declarations
- Terminology & Glossary
- EntityUid

---

## Systems

### Planned Lessons

- Barebones System
- Initialize()
- SubscribeLocalEvent()
- Events
- TryComp
- Dependencies
- Entity Queries
- EntityManager
- Components vs Systems

More examples will be added over time.

---

# Folder Structure

## C# Source Files

Components and Systems belong under `Content.Server`.

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

Prototype (`.yml`) files are **not** stored inside `Content.Server`.

Instead, they belong under the project's prototype resources.

```text
Resources/
└── Prototypes/
    └── _Starlight/
```

or another appropriate prototype folder within your project.

YAML prototypes are responsible for:

- Creating entities
- Adding Components
- Overriding `[DataField]` values
- Setting default entity configuration

---

## Example ECS Workflow

```text
Component (.cs)
        │
        │ Stores data
        ▼
System (.cs)
        │
        │ Reads and modifies data
        ▼
Prototype (.yml)
        │
        │ Creates the entity and configures Components
        ▼
Spawned Entity
```

---

> [!NOTE]
> Components and Systems are compiled C# code.
>
> Prototype (`.yml`) files are loaded separately by the engine and configure entities at runtime.
>
> Because of this, C# files and YAML files are stored in different locations.

---

# Who is this for?

This repository is aimed at:

- New SS14 contributors
- Hobby programmers
- Anyone learning ECS architecture
- Developers wanting documented examples instead of large code dumps

---

# Disclaimer

These templates are educational examples.

They are intentionally simple and focus on teaching concepts rather than implementing gameplay features.

Some examples are designed specifically to demonstrate how SS14's ECS architecture works and are **not intended for production use without modification**.

---

# License

Feel free to use, modify, and adapt these examples in your own SS14 projects.

Contributions, improvements, and corrections are always welcome.
