using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image[] heartsImage;
    private float _currentHealth;
    private Animator _anim;
    private float _timerProtect;
    private bool _isProtected;
    private Transform _spawnPoint;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        _spawnPoint = GameObject.FindGameObjectWithTag("Spawnpoint").transform;
    }

    private void Update()
    {
        UpdateProtected();
    }

    public void TakeDamageWithoutTeleport()
    {
        if (_isProtected) return;

        _anim.SetTrigger("Hit");
        TakeDamage();
    }

    public void TakeDamageWithTeleport()
    {
        _anim.Play("Appear");
        TakeDamage();
        transform.position = _spawnPoint.position;
    }

    private void TakeDamage()
    {
        _currentHealth--;
        _timerProtect = 1.5f;
        _isProtected = true;

        UpdateHeartsUI();

        if (_currentHealth <= 0)
        {
            _anim.SetTrigger("Dead");
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i =0; i<maxHealth; i++)
        {
            heartsImage[i].gameObject.SetActive(_currentHealth > i);
        }
    }  
    
    private void UpdateProtected()
    {
        if (_isProtected)
        {
            _timerProtect -= Time.deltaTime;
            if (_timerProtect <= 0f)
            {
                _isProtected = false;
            }
        }
    }

    private void Death()
    {
        GameLogic.instance.GameOver();
    }

    private void Win()
    {
        GameLogic.instance.Win();
    }
}
