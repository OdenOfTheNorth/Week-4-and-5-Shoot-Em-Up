using UnityEngine;

public class ShotGunPickUp : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody body;
    private Vector3 pos;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector3(0f,0f,-moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShotGun _shotGun = other.GetComponent<ShotGun>();
            _shotGun.canShoot_shotGun = true;
            Destroy(gameObject);
        }
    }
}
