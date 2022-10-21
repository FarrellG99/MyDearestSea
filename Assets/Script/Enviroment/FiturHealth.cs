using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiturHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject deathEffect;
    private float currentHealth;
    [SerializeField] private FilterHealthBar filterHealth;
    public GameObject Kalah;
    public GameObject gone;
    void Start()
    {
        currentHealth = _maxHealth;
        filterHealth.UpdateHealthBar(_maxHealth , currentHealth);
    }



    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));



                Kalah.SetActive(true);
                Time.timeScale = 0;
             
                    Cursor.visible = true;
                   
                

            }
            else
            {
                filterHealth.UpdateHealthBar(_maxHealth, currentHealth);
            }
        }

      

       
    }

    IEnumerator time()
    {
        gone.SetActive(false);

        yield return new WaitForSeconds(2);
        
        
       

    }

   
    void Update()
    {
       
        
    }
}
