using UnityEngine;

[RequireComponent(typeof(Movement), typeof(CharacterHealth))]
public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float maxShootingDistance = 4.5f;
    public LayerMask PlayerLayer;

    private Movement movement;
    private CharacterHealth health;
    private Transform playerTransform;
    private Vector3 playerPosition;
    private Vector3 vectorToPlayer;
    private ShootRifle _shoot;
    private Vector3 playerX;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
        health = GetComponent<CharacterHealth>();
        _shoot = GetComponent<ShootRifle>();
        _shoot.hitLayerShoot = PlayerLayer;
    }

    void Start()
    {
        playerTransform = GameController.GameControllerInstance.playerTransform;
        health.OnUnitDied += OnUnitDied;
    }

    void Update()
    {
        playerPosition = playerTransform.position;
        vectorToPlayer = playerPosition - transform.position;
        
        movement.movementInput = new Vector3(vectorToPlayer.x, vectorToPlayer.y, transform.forward.z);
        movement.DashInput = 1f;

        if (vectorToPlayer.sqrMagnitude <= maxShootingDistance * maxShootingDistance)
        {
            _shoot.shootInput = 1f;
        }
    }

    private void OnUnitDied()
    {
        GameController.GameControllerInstance.EnemyDied();
        Spawner.enemySpawnerInstance.EnemyDied();
        Destroy(gameObject);
    }
}