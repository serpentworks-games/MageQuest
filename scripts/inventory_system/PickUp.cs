using System.Diagnostics;
using Godot;

namespace MageQuest.InventorySystem
{
    public partial class PickUp : Area3D
    {
        [Export] public ItemType ItemType { get; private set; }
        [Export] public int amountToAdd { get; private set; }

        public override void _Ready()
        {
            BodyEntered += OnBodyEntered;
        }

        void OnBodyEntered(Node3D body)
        {
            Inventory inv = body.GetNodeOrNull<Inventory>("InventorySystem");
            if (inv == null) return;

            switch (ItemType)
            {
                case ItemType.Gold:
                    inv.UpdateGoldTotal(amountToAdd);
                    Debug.Print($"Adding gold: {amountToAdd}");
                    break;
                case ItemType.BasicKey:
                    inv.UpdateKeyCount(amountToAdd);
                    Debug.Print($"Adding keys: {amountToAdd}");
                    break;
            }

            QueueFree();

        }
    }
}