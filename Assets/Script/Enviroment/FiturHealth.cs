using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiturHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject deathEffect;
    private float currentHealth;
    [SerializeField] private FilterHealthBar filterHealth;
    void Start()
    {
        currentHealth = _maxHealth;
        filterHealth.UpdateHealthBar(_maxHealth , currentHealth);
    }



    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
            gameObject.SetActive(false);
        }
        else
        {
            filterHealth.UpdateHealthBar(_maxHealth, currentHealth);
        }
    }

    private void OnMouseDown()
    {
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
            gameObject.SetActive(false);
        }
        else
        {
            filterHealth.UpdateHealthBar(_maxHealth, currentHealth);
        }
    
}
    void Update()
    {
       
        
    }
}
