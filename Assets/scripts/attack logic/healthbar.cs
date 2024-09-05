using TMPro;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public GameObject greenBar; // The green GameObject
    public float maxHealth = 0; // Maximum health
    public float currentHealth; // Current health
    BaseLogic bas;
    public TextMeshProUGUI text;

    private float originalGreenBarWidth; // Store the original width of the green bar

    void Start()
    {
        bas = FindObjectOfType<BaseLogic>();
        

        // Record the original width of the green bar
        originalGreenBarWidth = greenBar.transform.localScale.x;
        SetHealth();
    }

    void Update()
    {
        // Update the health bar
    }

    internal void UpdateHealthBar()
    {
        // Calculate the percentage of health remaining
        currentHealth = bas.threshold;
        float healthPercentage = currentHealth / maxHealth;

        // Update the width of the green bar proportionally to the health percentage
        greenBar.transform.localScale = new Vector3(originalGreenBarWidth * healthPercentage, greenBar.transform.localScale.y, greenBar.transform.localScale.z);

        Debug.Log($"health: {currentHealth}");
        // Update the health text
        text.text = $"{currentHealth} / {maxHealth}";
    }

    internal void SetHealth()
    {
        maxHealth = bas.threshold;
        currentHealth = maxHealth; // Initialize current health to max health
        text.text = $"{currentHealth} / {maxHealth}";
        float healthPercentage = currentHealth / maxHealth;
        greenBar.transform.localScale = new Vector3(originalGreenBarWidth * healthPercentage, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
    }
}
