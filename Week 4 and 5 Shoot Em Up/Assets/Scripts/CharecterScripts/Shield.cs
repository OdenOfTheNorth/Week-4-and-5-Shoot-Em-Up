using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerInput _playerInput;
    //[NonSerialized] 
    public bool canTakeDamage = true;
    public float Shieldinput;

    //Shield up time
    public float ShieldUpTime = 3f;
    private float _currentShieldTimer;

    //Shield Cooldown Time
    public float ShieldCoolDown = 5f;
    private float _currentShieldCoolDown = 0f;

    [NonSerialized]public bool _activateShireld = false;
    private void Awake()
    {
        _currentShieldTimer = ShieldUpTime;
        _playerInput = GetComponent<PlayerInput>();
        _currentShieldCoolDown = ShieldCoolDown;
    }

    private void Update()
    {
        _playerInput.ShieldSlider.value = _currentShieldCoolDown / ShieldCoolDown;
        if (_currentShieldCoolDown >= ShieldCoolDown && Shieldinput != 0f)
        {
            _activateShireld = true;
        }
        else
        {
            _currentShieldCoolDown += Time.deltaTime;
        }

        if (_activateShireld)
        {
            ShieldActivate();
        }
    }

    public void ShieldActivate()
    {
        canTakeDamage = false;
        _currentShieldTimer -= Time.deltaTime;
        _playerInput.ShieldSlider.value = _currentShieldTimer / ShieldUpTime;
        if (_currentShieldTimer <= 0f)
        {
            canTakeDamage = true;
            _currentShieldTimer = ShieldUpTime;
            _activateShireld = false;
            _currentShieldCoolDown = 0f;
        }
    }
}
