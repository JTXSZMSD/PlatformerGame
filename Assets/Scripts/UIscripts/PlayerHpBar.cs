using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{

    public Slider slider;
    public Health playerHealth;

    private void Start()
    {
        SetMaxHealth(playerHealth.maxHealth);
    }

    private void Update()
    {
        SetHealth(playerHealth.health);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    //int playerHealth;
    //private GameObject healthBarSlider;

    //void Start()
    //{
    //    playerHealth = player.GetComponent<Health>().health;
    //    healthBarSlider = GetComponent<Slider>;
    //}

    //void Update()
    //{
    //    UpdateHealthBar(playerHealth);
    //}

    //public void UpdateHealthBar(int currentHealth)
    //{
    //    healthBarSlider.maxValue = 100;
    //    healthBarSlider.minValue = 0;
    //    healthBarSlider.value = currentHealth;
    //}
}
