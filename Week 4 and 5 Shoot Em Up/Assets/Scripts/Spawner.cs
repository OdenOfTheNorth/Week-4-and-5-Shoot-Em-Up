using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public static Spawner enemySpawnerInstance = null;
    
    public Transform SpawnerLocation;
    public GameObject Enemy;
    public GameObject EnemyRandom;
    public GameObject ShotGunPickUp;
    private GameObject player;
    public bool canSpawn = true;
    [NonSerialized]public int enemiesAlive = 0;
    public int enemysPerWave = 5;
    
    private ShotGun _shotGun;
    private Vector3 screenBounds;
    


    [FormerlySerializedAs("waveSizeIncrease")] public int NextwaveSizeIncrease = 2;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        enemySpawnerInstance = this;
    }



    private void Start()
    {
        player = GameController.GameControllerInstance.playerGameobject;
        _shotGun = player.GetComponent<ShotGun>();
        SpawnWave();
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0 && canSpawn)
        {
            enemysPerWave += NextwaveSizeIncrease;
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        
        //enemiesAlive += enemysPerWave;
        
        Vector3 pos = new Vector3(Random.Range(screenBounds.x,-screenBounds.x),SpawnerLocation.transform.position.y,SpawnerLocation.transform.position.z);
        for (int i = 0; i < enemysPerWave/2f; i++)
        {
            pos = new Vector3(Random.Range(screenBounds.x,-screenBounds.x),SpawnerLocation.transform.position.y,SpawnerLocation.transform.position.z);
            Instantiate(Enemy, pos, SpawnerLocation.rotation);
            pos = new Vector3(Random.Range(screenBounds.x,-screenBounds.x),SpawnerLocation.transform.position.y,SpawnerLocation.transform.position.z);
            Instantiate(EnemyRandom, pos, SpawnerLocation.rotation);
            enemiesAlive += 2;
        }
        
        if (!_shotGun.canShoot_shotGun)
        {
            Instantiate(ShotGunPickUp, pos, SpawnerLocation.rotation);    
        }
        
    }
}
