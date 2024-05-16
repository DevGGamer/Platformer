using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    [SerializeField] private Text gemsText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject deathPanel;
    private int _gemsCount = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        winPanel.SetActive(false);
        deathPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateGemsCount(int value)
    {
        _gemsCount += value;
        gemsText.text = _gemsCount.ToString();
    }

    public void GameOver()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
