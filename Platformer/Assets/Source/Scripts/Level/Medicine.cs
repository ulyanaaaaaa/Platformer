using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private int _health;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Restore(_health);
            Destroy(gameObject);
        }
    }
}
