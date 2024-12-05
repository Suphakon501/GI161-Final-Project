using UnityEngine;

public class HealthPotion : Potion
{
    public override void ApplyPotion(Character character)
    {
        // เพิ่มค่า Health ให้กับตัวละคร
        character.Health += 20;
    }
}
