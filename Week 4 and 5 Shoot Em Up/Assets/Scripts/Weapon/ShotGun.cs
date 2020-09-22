using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ShotGun : MonoBehaviour , IWeapon
{
    
    [FormerlySerializedAs("projectile")] [SerializeField] private GameObject Bullet;
    public Transform origin;
    public float damage = 50f;
    public float coolDown = 0.2f;
    public float Pellets = 2f;
    public float Spread = 5f;

    public bool canShoot_shotGun = false;

    
    private float currentCoolDown = 0f;
    private bool _shotGun = false;
    [NonSerialized] public float shootGunInput;
    [NonSerialized] public LayerMask hitLayerShoot;

    public float PowerUpTime = 4f;
    private float currentPowerUpTime;
    [NonSerialized] public bool powerUp = false;

    private void Awake()
    {
        currentPowerUpTime = PowerUpTime;
    }

    void Update()
    {
        if (canShoot_shotGun)
        {
            currentCoolDown -= Time.deltaTime;
            if (shootGunInput != 0f && currentCoolDown <= 0f)
            {
                _shotGun = true;
            }

            if (_shotGun)
            {
                //
                for (int i = 0; i < Pellets/2; i++)
                {
                    if (i == 0)
                    {
                        CreateBullet(0f);
                    }
                    else
                    {
                        CreateBullet(i);
                        CreateBullet(-i);
                    }
                }
                _shotGun = false;
                currentCoolDown = coolDown;
            }
        }
    }
    public void CreateBullet(float f1)
    {
        float angle = Spread * f1;
        Quaternion originOffset = Quaternion.AngleAxis(angle ,Vector3.up);
        //Quaternion test = originOffset + new Vector3(origin.position.x,origin.position.y,origin.position.z);
        GameObject bullet = Instantiate(Bullet, origin.position, originOffset);
        Bullet bulletBehavior = bullet.GetComponent<Bullet>();
        bulletBehavior.Initialize(damage,hitLayerShoot);
    }
}
