using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(player.MaxHealth);
        }
    }
}
