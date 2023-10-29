using Godot;
using System;
using DialogueManagerRuntime;

public partial class Test : Control
{
    [Export(PropertyHint.File, "*.dialogue")] string dialogueFile;
    public override void _Ready()
    {
        var resource = GD.Load<Resource>(dialogueFile);
        DialogueManager.ShowExampleDialogueBalloon(resource, "testStart");
    }
}
