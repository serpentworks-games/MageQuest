using Godot;
namespace MageQuest.Combat
{
    public partial class HealthData : Resource
    {
        [Export] public int MaxHealth { get; private set; }

        int currentHealth;

        public void UpdateCurrentHealth(int value)
        {
            currentHealth += value;
        }
    }
}