using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject _deathEffect;
    private float _currentHealth;
    [SerializeField] private EnemyHealthBar _healthbar;
    [SerializeField] private float DamageWeaponTake;
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.UpdateHelathBar(_maxHealth, _currentHealth);
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.tag == "Bullet")
        {
            _currentHealth -= DamageWeaponTake;
            Debug.Log("KenaLoo1");
            Die();
           
        }
        if (other.gameObject.tag == "FilterAir")
        {
            Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);

        }
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }


    }

    public void Die()
    {
        _currentHealth -= 1;
        if (_currentHealth <= 0)
        {
            Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
         
        }
        else
        {
            _healthbar.UpdateHelathBar(_maxHealth, _currentHealth);
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
       
    }
 
    //private void OnMouseDown()
    //{
    //    _currentHealth -= Random.Range(0.5f, 1.5f);
    //    if(_currentHealth <= 0 )
    //    {
            
    //        Destroy(gameObject);
    //    }else
    //    {
    //        _healthbar.UpdateHelathBar(_maxHealth, _currentHealth); 
          
    //    }


    //}
}
