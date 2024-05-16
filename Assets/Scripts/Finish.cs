using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject helpObject;
    [SerializeField] private Animator playerAnim;

    private Animator finishAnim;
    private bool isActivated = false;
    private bool playerInside = false;

    private void Start()
    {
        finishAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInside)
        {
            finishAnim.SetTrigger("pressed");
            isActivated = true;
            helpObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
            helpObject.SetActive(playerInside = true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            helpObject.SetActive(playerInside = false);
    }

    private void WinPlayer()
    {
        playerAnim.SetTrigger("Win");
    }
}
