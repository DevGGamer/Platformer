using UnityEngine;

public class FireTrap : Damagable
{
    [SerializeField] private float timeTurn;
    private float timer;
    private Animator _anim;
    private bool isOn = true;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTurn)
        {
            _anim.SetBool("isOn", isOn = !isOn);
            timer = 0f;
        }
    }
}
