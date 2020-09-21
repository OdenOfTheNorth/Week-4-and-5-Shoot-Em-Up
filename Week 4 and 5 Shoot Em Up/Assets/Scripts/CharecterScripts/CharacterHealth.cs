using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float healthRegeneration = 1.0f;
    private Shield _shield;

    public float currentHealth = 0.0f;

    public delegate void UnitDied();
    public UnitDied OnUnitDied;

    public delegate void HealthChanged(float maxHealth, float currentHeatlh);
    public HealthChanged OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
        _shield = GetComponent<Shield>();
    }

    void Update()
    {
        if (healthRegeneration > Mathf.Epsilon)
        {
            TakeDamage(-healthRegeneration * Time.deltaTime * 3f);
        }
    }

    public void TakeDamage(float damage)
    {
        if (_shield)
        {
            if (_shield.canTakeDamage)
            {
                currentHealth -= damage;
            }
            else
            {
                currentHealth += healthRegeneration * Time.deltaTime * 3f;
            }
        }
        
        currentHealth -= damage;
        
        OnHealthChanged?.Invoke(maxHealth, currentHealth);

        if (currentHealth <= 0.0f)
        {
            OnUnitDied?.Invoke();
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
