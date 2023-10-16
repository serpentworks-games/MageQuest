using Godot;
using System;
using System.Diagnostics;

namespace MageQuest.InventorySystem
{
    public partial class Inventory : Node
    {
        int currentGold, currentKeys;
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(double delta)
        {
        }

		public int GetGoldTotal()
		{
            return currentGold;
        }

		public int GetKeyTotal()
		{
            return currentKeys;
        }

        public void UpdateGoldTotal(int value)
        {
            currentGold += value;
            Debug.Print($"Current Gold: {currentGold}");
            if (currentGold < 0) currentGold = 0;
        }

        public void UpdateKeyCount(int value)
        {
            currentKeys += value;
			Debug.Print($"Current Keys: {currentKeys}");
            if (currentKeys < 0) currentKeys = 0;
        }
    }
}