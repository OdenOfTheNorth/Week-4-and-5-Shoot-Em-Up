using System;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float timeToLive = 5.0f;
    [NonSerialized] public LayerMask hitlayerBullet;
    
    private float damage = 0;

    public void Initialize(float bulletDamage, LayerMask hit)
    {
        damage = bulletDamage;
        hitlayerBullet = hit;
    }
    
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0f)
        {
            Destroy(gameObject);
        }

        transform.position += Time.deltaTime * moveSpeed * gameObject.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        int layer = (int) Mathf.Log(hitlayerBullet.value, 2);
        
        if (other.gameObject.layer == layer)
        {
            CharacterHealth otherHealth = other.GetComponent<CharacterHealth>();
            otherHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
