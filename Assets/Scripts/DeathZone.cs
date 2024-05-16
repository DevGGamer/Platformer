using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
        if (playerHealth) playerHealth.TakeDamageWithTeleport();
    }
}
