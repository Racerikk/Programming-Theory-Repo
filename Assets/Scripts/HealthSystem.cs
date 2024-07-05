using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float maxHealth = 3;
    float currentHealth;
    [SerializeField] GameObject damageOverlay;
    [SerializeField] GameObject loseGameUI;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damage)
    {
        StartCoroutine(FlashDamageOverlay());
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FlashDamageOverlay()
    {
        damageOverlay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageOverlay.SetActive(false);
    }

    private void OnDestroy()
    {
        ScoreManager.instance.GameOver();
        loseGameUI.SetActive(true);
    }
}
