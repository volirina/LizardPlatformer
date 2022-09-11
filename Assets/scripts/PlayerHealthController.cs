using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    private int currentHealth;
    public int maxHealth;

    public float invincibilityLength = 1f;
    private float invinCounter;

    public GameObject[] modelDisplay;
    private float flashCounter;
    public float flashTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        FillHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (invinCounter > 0)
        {
            invinCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter<=0)
            {
                flashCounter = flashTime;

                foreach(GameObject piece in modelDisplay)
                {
                    piece.SetActive(!piece.activeSelf);
                }
            }
            if(invinCounter<=0)
            {
                foreach (GameObject piece in modelDisplay)
                {
                    piece.SetActive(true);
                }
            }
        }
    }

    public void DamagePlayer()
    {
        if(invinCounter<=0)
        {
            invinCounter = invincibilityLength;

            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                LevelManager.instance.Respawn();
               
            }

            UIController.instance.UpdateHealthDisplay(currentHealth);
        }


    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthDisplay(currentHealth);
    }
}
