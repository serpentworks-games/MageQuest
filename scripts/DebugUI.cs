using Godot;
using MageQuest.InventorySystem;
using System;
using System.Diagnostics;

namespace MageQuest.UI
{
    public partial class DebugUI : Node
    {
        [Export] RichTextLabel goldValueLabel;
        [Export] RichTextLabel keyValueLabel;

        Inventory inv;

        public override void _Ready()
        {
            inv = GetNode<Inventory>("../Characters/Player/InventorySystem");
        }

        public override void _Process(double delta)
        {
            goldValueLabel.Text = $"{inv.GetGoldTotal()}";
            keyValueLabel.Text = $"{inv.GetKeyTotal()}";
        }
    }
}
