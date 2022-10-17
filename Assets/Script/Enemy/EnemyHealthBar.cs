using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;
    [SerializeField] private float _reduceSpeed = 2;
    private float _target = 1;
    public void UpdateHelathBar(float maxHealth, float currentHealth)
    {
        _target= currentHealth / maxHealth;
    }

    private void Update()
    {
        _healthBarSprite.fillAmount = Mathf.MoveTowards(_healthBarSprite.fillAmount, _target, _reduceSpeed * Time.deltaTime);
    }
}
