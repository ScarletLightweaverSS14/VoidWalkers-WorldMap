namespace Content.Server._Starlight.LearningCSharp.Components;
/// <summary>
/// Demonstrates how DataFields allow Components to store configurable data.
/// </summary>
[RegisterComponent]
public sealed partial class DataFieldTemplateComponent : Component
{
    [DataField]
    public string Name = "Examplename";
}
