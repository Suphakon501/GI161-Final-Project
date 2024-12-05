using UnityEngine;

public class SpeedBoostPotion : Potion
{
    public float speedMultiplier = 2.0f;
    public float duration = 2.5f;

    public override void ApplyPotion(Character character)
    {
        if (character is Player player) 
        {
            player.ApplyPotion(speedMultiplier, duration);
        }
    }
}
