using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    //[SerializeField] private GameObject _deathEffect, _hitEffect;
    private float _currentHealth;
    [SerializeField] private EnemyHealthBar _healthbar;
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthbar.UpdateHelathBar(_maxHealth, _currentHealth);
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        _currentHealth -= Random.Range(0.5f, 1.5f);
        if(_currentHealth <= 0 )
        {
            
            Destroy(gameObject);
        }else
        {
            _healthbar.UpdateHelathBar(_maxHealth, _currentHealth); 
          
        }


    }
}
