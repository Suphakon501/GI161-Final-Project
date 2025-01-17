using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] Character theCharacter;
    private void Start()
    {
        SetMaxHealth(theCharacter.Health);
    }
    private void Update()
    {
        UpdateHealthBar(theCharacter.Health);
    }
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        //Debug.Log($"Health slider: {healthSlider.value} / {healthSlider.maxValue}");
    }
    public void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
    }
}