using UnityEngine;

public class Pickable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameLogic.instance.UpdateGemsCount(1);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.2f);
            
        }
    }
}
