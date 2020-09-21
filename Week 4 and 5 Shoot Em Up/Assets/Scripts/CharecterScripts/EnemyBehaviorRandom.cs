using UnityEngine;

[RequireComponent(typeof(Movement), typeof(CharacterHealth))]
public class EnemyBehaviorRandom : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public int SwayX = 5;

    private Movement movement;
    private CharacterHealth health;
    private ShootRifle _shoot;
    private Vector3 position;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        health = GetComponent<CharacterHealth>();
        _shoot = GetComponent<ShootRifle>();
        _shoot.hitLayerShoot = PlayerLayer;
    }

    void Start()
    {
        health.OnUnitDied += OnUnitDied;
    }

    void Update()
    {
        float randomX = Mathf.Sin(Time.time) * SwayX;
        position = new Vector3(randomX, 0f, 0f);
        
        movement.movementInput = new Vector3(position.x, position.y, transform.forward.z);
        
        movement.DashInput = 1f;
        _shoot.shootInput = 1f;
    }

    private void OnUnitDied()
    {
        GameController.GameControllerInstance.EnemyDied();
        Spawner.enemySpawnerInstance.EnemyDied();
        Destroy(gameObject);
    }
}