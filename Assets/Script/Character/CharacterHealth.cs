using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] private GameObject _deathEffect;
    private float _currentHealth;
    [SerializeField] private CharacterHealthBar _healthBar;
    private Animator anim;
    CapsuleCollider playerCollider;
    
    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _currentHealth -= 1;
            Debug.Log("KenaLoo");

            if (_currentHealth ==  0f)
            {
                //Instantiate(_deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
                anim.SetBool("Die",true);
                playerCollider.height = 1.23f;
                //gameObject.SetActive(false);
                StartCoroutine("die");
              
               

            }
           
            else
            {
                _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
                //Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<CharacterLocomotion>().enabled = false;
        GetComponent<CharacterAiming>().enabled = false;
    }
   
}
