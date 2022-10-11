using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject _deathEffect;
    private float _currentHealth;
    [SerializeField] private CharacterHealthBar _healthBar;
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHealth -= 1;
            Debug.Log("KenaLoo1");

            if (_currentHealth <= 0)
            {
                Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
                Destroy(gameObject);
            }
            else
            {
                _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
                //Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }
    }
   
}
