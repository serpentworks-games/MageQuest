using System.Diagnostics;
using Godot;
using MageQuest.InteractionSystem.Actions;

namespace MageQuest.InteractionSystem
{
    public partial class StringPrinter : InteractionAction
    {
        [Export] string textToPrintToConsole = "";

        public override void PerformInteraction()
        {
            Debug.Print(textToPrintToConsole);
        }
    }
}