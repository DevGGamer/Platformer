using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject moveablePlatform;
    [SerializeField] private GameObject helpObject;
    private bool playerInside = false;
    private bool isActivated = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInside)
        {
            moveablePlatform.SetActive(true);
            isActivated = true;
            helpObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isActivated) helpObject.SetActive(playerInside = true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        helpObject.SetActive(playerInside = false);
    }
}
