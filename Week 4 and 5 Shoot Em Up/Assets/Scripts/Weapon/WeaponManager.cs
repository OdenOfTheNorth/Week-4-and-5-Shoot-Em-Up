using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public BaseWeapon[] Weapons;

    private PlayerInput _playerInput;
    //[NonSerialized]
    public int scroolwheel = 0;
    public int test = 0;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        foreach (var baseWeapon in Weapons)
        {
            BaseWeapon[] weapons = GetComponent<BaseWeapon[]>();
        }
    }

    private void Update()
    {
        scroolwheel = _playerInput.playerScroolwheel;
        
        if (scroolwheel < 0)
        {
            test = 0;
        }
        if (scroolwheel > 0)
        {
            test = 1;
        }
        Weapons[test].Shoot();
        Debug.Log(test);
    }
}
