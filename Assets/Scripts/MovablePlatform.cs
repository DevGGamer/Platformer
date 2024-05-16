using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private Transform pointStart;
    [SerializeField] private Transform pointEnd;
    [SerializeField] private float moveSpeed;
    private bool playerStay = false;
    private Rigidbody2D platform;

    private void Start()
    {
        platform = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerStay)
            platform.position = Vector2.MoveTowards(platform.position, pointEnd.position, moveSpeed);
        else
            platform.position = Vector2.MoveTowards(platform.position, pointStart.position, moveSpeed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerStay = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerStay = false;
    }
}
