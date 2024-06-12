using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    public Action ChangeHealthBar;
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Health { get; private set; }

    private SceneService _sceneService;
    
    [Inject]
    public void Constructor(SceneService sceneService)
    {
        _sceneService = sceneService;
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        
        if (Health <= 0)
            _sceneService.Restart();
        
        ChangeHealthBar?.Invoke();
    }
    
    public void Restore(int health)
    {
        if (Health == MaxHealth)
            return;
        
        Health += health;
        ChangeHealthBar?.Invoke();
    }
}
