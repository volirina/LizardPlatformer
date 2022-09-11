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
    public Image fadeScreenDeath;
    public bool isFadingToBlack, isFadingToTransparent;

    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadingToBlack)
        {
            fadeScreenDeath.color = new Color(fadeScreenDeath.color.r, fadeScreenDeath.color.g, fadeScreenDeath.color.b, Mathf.MoveTowards(fadeScreenDeath.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
        if (isFadingToTransparent)
        {
            fadeScreenDeath.color = new Color(fadeScreenDeath.color.r, fadeScreenDeath.color.g, fadeScreenDeath.color.b, Mathf.MoveTowards(fadeScreenDeath.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
    }
    public void FadeToBlack()
    {
        isFadingToBlack = true;
        isFadingToTransparent = false;
    }

    public void FadeToTransparent()
    {
        isFadingToTransparent = true;
        isFadingToBlack = false;
    }
    public void UpdateHealthDisplay(int health)
    {
        healthText.text = "HEALTH: " + health + "/" + PlayerHealthController.instance.maxHealth;
        healthSlider.maxValue = PlayerHealthController.instance.maxHealth;
        healthSlider.value = health;
    }
}
