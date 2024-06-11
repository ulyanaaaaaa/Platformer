using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    public Action ChangeHealthBar;
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Health { get; private set; }

    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        ChangeHealthBar?.Invoke();
    }
    
    public void Restore(int health)
    {
        Health += health;
        ChangeHealthBar?.Invoke();
    }
}
