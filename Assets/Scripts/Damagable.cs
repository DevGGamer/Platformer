using UnityEngine;

public class Damagable : MonoBehaviour
{
    protected void OnTriggerStay2D(Collider2D collision)
    {
        collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
        playerHealth.TakeDamageWithoutTeleport();
    }
}
