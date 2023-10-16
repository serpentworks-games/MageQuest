using Godot;
using MageQuest.InventorySystem;

namespace MageQuest.InteractionSystem.Actions
{
    public partial class CheckInventory : InteractionAction
    {
        [Export(PropertyHint.Enum)] ItemType itemType;
        [Export] int requiredAmount;
        [Export] InteractionAction[] hasRequiredAmountActions;
        [Export] InteractionAction[] lessThanRequiredAmountActions;

        [Export] Node3D player;

        Inventory playerInv;

        public override void _Ready()
        {
            playerInv = (Inventory)player.GetNode("InventorySystem");
        }

        public override void PerformInteraction()
        {
            if (playerInv == null) return;

            int currentAmount = 0;

            switch (itemType)
            {
                case ItemType.Gold:
                    currentAmount = playerInv.GetGoldTotal();
                    break;
                case ItemType.BasicKey:
                    currentAmount = playerInv.GetKeyTotal();
                    break;
            }

            if (currentAmount >= requiredAmount)
            {
                foreach (var action in hasRequiredAmountActions)
                {
                    action.OnInteraction();
                    return;
                }
            }

            if (currentAmount < requiredAmount)
            {
                if (lessThanRequiredAmountActions == null) return;
                foreach (var action in lessThanRequiredAmountActions)
                {
                    action.OnInteraction();
                    return;
                }
            }
        }
    }
}