using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject VictoryPanel;

    void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }
    void Start()
    {
        PausePanel.SetActive(false);
        VictoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = !PausePanel.activeSelf ? 0f : 1f;
            PausePanel.SetActive(!PausePanel.activeSelf);
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        VictoryPanel.SetActive(true);
    }
}
