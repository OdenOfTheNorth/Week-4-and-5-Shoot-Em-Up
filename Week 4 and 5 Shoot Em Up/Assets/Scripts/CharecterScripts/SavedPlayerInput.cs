using System;
using UnityEngine;
using UnityEngine.UI;

public class SavedPlayerInput : MonoBehaviour 
{
    [SerializeField] private Slider healthSlider = null;
    public Slider ShieldSlider = null;
    
    public LayerMask enemyLayer;
   
    private Movement _movement;
    private ShootRifle _shoot;
    private ShotGun _shotGun;
    private BaseWeapon _baseWeapon;
    private WeaponManager _manager;
    private CharacterHealth _health;
    private Shield _shield;
    [NonSerialized]public int playerScroolwheel;
    
    void Awake()
    {
        _movement = GetComponent<Movement>();
        _shoot = GetComponent<ShootRifle>();
        _shotGun = GetComponent<ShotGun>();
        _health = GetComponent<CharacterHealth>();
        _manager = GetComponent<WeaponManager>();
        _baseWeapon = GetComponent<BaseWeapon>();
        _shield = GetComponent<Shield>();
        _health.OnUnitDied += OnPlayerDied;
        _health.OnHealthChanged += OnHealthChanged;
        GameController.GameControllerInstance.playerTransform = transform;
        GameController.GameControllerInstance.playerGameobject = gameObject;
        //_shoot.hitLayerShoot = enemyLayer;
        //_shotGun.hitLayerShoot = enemyLayer;
        _baseWeapon.hitLayerShoot = enemyLayer;
    }

    void Update()
    {
        _movement.movementInput.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _movement.DashInput = Input.GetAxis("Dash");
        _shoot.shootInput = Input.GetAxis("Fire1");
        _shotGun.shootGunInput = Input.GetAxis("Fire2");
        _shield.Shieldinput = Input.GetAxis("ShieldInput");

        //_shoot.shootInput = Input.GetAxis("Fire1");
        _baseWeapon.shootInput = Input.GetAxis("Fire1");
        //playerScroolwheel = Convert.ToInt16(Input.GetAxis("Mouse ScrollWheel") * 10f);
    }
    
    private void OnPlayerDied()
    {
        GameController.GameControllerInstance.PlayerDied();
    }
    
    private void OnHealthChanged(float maxHealth, float currentHealth)
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
