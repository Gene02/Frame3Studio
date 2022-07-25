using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int maxHealth, currentHealth;
    private float invincibleCounter;
    public float invincibleLength;
    
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health" + currentHealth + "/" + maxHealth;
    }

    
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invincibleCounter <= 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                GameManager.instance.PlayerDied();
            }

            invincibleCounter = invincibleLength;

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "Health" + currentHealth + "/" + maxHealth;
        }
       
    }
}
