using GameEventSystem.Chanels;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float _currentHealth;

    
    
    [SerializeField]
    private FloatEventChanel UI_Connection;

     private float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (ReferenceEquals(UI_Connection,null)) return;
            UI_Connection.Publish(_currentHealth / maxHealth);
        }
    }
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        CurrentHealth -= 1;
    }

    public void Heal()
    {
        CurrentHealth = maxHealth;
    }
}