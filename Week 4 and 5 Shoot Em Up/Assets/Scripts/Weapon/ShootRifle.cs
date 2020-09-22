using System;
using UnityEngine;

public class ShootRifle : MonoBehaviour , IWeapon
{

    
    [SerializeField] private GameObject Bullet;
    public Transform origin;
    public float damage = 50f;
    public float coolDown = 0.5f;
        
    private float currentCoolDown = 0f;
    [NonSerialized] public float shootInput;
    [NonSerialized] public LayerMask hitLayerShoot;
    

    void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if (shootInput != 0f)
        {
            CreateBullet(damage);
        }
    }

    public void Shoot(float f1)
    {
        if (currentCoolDown <= 0f)
        {
            currentCoolDown = coolDown;
            GameObject projectileInstance = Instantiate(Bullet, origin.position, origin.rotation);
            Bullet bulletBehavior = projectileInstance.GetComponent<Bullet>();
            bulletBehavior.Initialize(f1,hitLayerShoot);
        }
    }

    public void CreateBullet(float f1)
    {
        if (currentCoolDown <= 0f)
        {
            currentCoolDown = coolDown;
            GameObject projectileInstance = Instantiate(Bullet, origin.position, origin.rotation);
            Bullet bulletBehavior = projectileInstance.GetComponent<Bullet>();
            bulletBehavior.Initialize(f1,hitLayerShoot);
        }
    }
}
