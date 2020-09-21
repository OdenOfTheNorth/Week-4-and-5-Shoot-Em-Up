using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    bool IsEnable { set; get; }
    //string Name { set;  }
    void Shoot();
}