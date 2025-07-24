using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Slider healthSlider;

    private int maxHealth;

    private void Awake()
    {
        maxHealth = health;
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            ChangeUI();
        }
    }

    private void ChangeUI()
    {
        healthSlider.value = health;
    }

    public void IncreaseHealthOnRest()
    {
        health += 10;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        ChangeUI();
    }


}
