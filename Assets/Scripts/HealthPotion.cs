using UnityEngine;

public class HealthPotion : Potion
{
    public override void ApplyPotion(Character character)
    {
        // ������� Health ���Ѻ����Ф�
        character.Health += 20;
    }
}
