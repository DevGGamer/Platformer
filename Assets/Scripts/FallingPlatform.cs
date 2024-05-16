using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;
    private Vector2 startPosition;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _anim.SetTrigger("Collision");
            StartCoroutine(StartTimer());
        }
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(15f);
        _rb.bodyType = RigidbodyType2D.Static;
        transform.position = startPosition;
        _anim.Play("idle");
    }
}
