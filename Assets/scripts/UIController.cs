using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider healthSlider;
    public TMP_Text healthText, appleText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay(int health)
    {
        healthText.text = "HEALTH: " + health + "/" + PlayerHealthController.instance.maxHealth;
        healthSlider.maxValue = PlayerHealthController.instance.maxHealth;
        healthSlider.value = health;
    }
}
