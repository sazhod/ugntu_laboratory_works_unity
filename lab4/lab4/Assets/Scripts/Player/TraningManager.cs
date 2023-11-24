using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TRaningManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private Text resultText;
    [SerializeField] private Canvas endCanvas;

    private float currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        endCanvas.enabled = false;
    }


    void TakeDamage(float damage)
    {
        if (currentHealth < 0)
        {
            resultText.text = "Вы не справились!";
            Time.timeScale = 0;
            endCanvas.enabled = true;
        }
        else
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }

    private void FixedUpdate()
    {
        TakeDamage(damage * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {

    }

}
