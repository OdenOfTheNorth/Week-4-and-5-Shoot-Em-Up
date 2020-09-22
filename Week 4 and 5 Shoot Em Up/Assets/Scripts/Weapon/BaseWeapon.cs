using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseWeapon : MonoBehaviour , IWeapon
{
    //public IWeapon[] Weapons;
    [FormerlySerializedAs("projectile")] [SerializeField] private GameObject Bullet;
    public Transform origin;
    public float damage = 50f;
    public float coolDown = 0.2f;
    
    [FormerlySerializedAs("useSpread")] public bool useBullets = false;
    [FormerlySerializedAs("canShoot_shotGun")] public bool canShoot = true;

    
    private float currentCoolDown = 0f;
    private bool _Shoot = false;
    [NonSerialized] public float shootInput;
    [NonSerialized] public LayerMask hitLayerShoot;
    private Quaternion savedRoatation;

    private void Awake()
    {
        savedRoatation = origin.rotation;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        currentCoolDown -= Time.deltaTime;
        if (canShoot)
        {
            if ((shootInput != 0f && currentCoolDown <= 0f) )
            {
                _Shoot = true;
            }

            if (_Shoot)
            {
                if (useBullets)
                {
                    CreateBullet(1);
                }
                else
                {
                    DoRayCast();
                }
                _Shoot = false;
                currentCoolDown = coolDown;
            }
        }
    }

    public void DoRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position,origin.forward,out hit,100, hitLayerShoot))
        {
            CharacterHealth hitUnit = hit.transform.GetComponent<CharacterHealth>();
            if (hitUnit)
            {
                hitUnit.TakeDamage(damage);
            }
        }
    }

    public void CreateBullet(float i)
    {
        GameObject bullet = Instantiate(Bullet, origin.position, origin.rotation);
        Bullet bulletBehavior = bullet.GetComponent<Bullet>();
        bulletBehavior.Initialize(damage, hitLayerShoot);
    }
}
