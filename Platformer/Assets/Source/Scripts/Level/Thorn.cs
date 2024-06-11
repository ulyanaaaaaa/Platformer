using UnityEngine;

public class Thorn : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
