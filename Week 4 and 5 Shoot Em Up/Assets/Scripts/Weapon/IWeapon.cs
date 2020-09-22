using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    //void Shoot();
    //bool canShot,float damage,float spread,float cooldown,GameObject bullet
    void CreateBullet(float f1);
}