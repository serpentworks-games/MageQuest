using Godot;
using MageQuest.InventorySystem;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class AddToInventory : InteractionAction
    {
        [Export(PropertyHint.Enum)] ItemType itemType;
        [Export] int amountToAdd;

        Inventory inv;

        public override void _Ready()
        {
            inv = GetNode<Inventory>("../Characters/Player/InventorySystem");
        }

        public override void PerformInteraction()
        {
            switch (itemType)
            {
                case ItemType.Gold:
                    inv.UpdateGoldTotal(amountToAdd);
                    break;
                case ItemType.BasicKey:
                    inv.UpdateKeyCount(amountToAdd);
                    break;
            }
        }
    }
}