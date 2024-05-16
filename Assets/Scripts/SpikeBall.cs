using UnityEngine;

public class SpikeBall : Damagable
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform rotateObject;

    private void Update()
    {
        rotateObject.eulerAngles += Vector3.forward * rotateSpeed * Time.deltaTime;
    }
}
