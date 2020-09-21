using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController gameControllerInstance = null;
    public static GameController GameControllerInstance
    {
        get
        {
            if (gameControllerInstance == null)
            {
                gameControllerInstance = FindObjectOfType<GameController>();
            }
            return gameControllerInstance;
        }
    }

    [HideInInspector] public Transform playerTransform = null;
    [HideInInspector] public GameObject playerGameobject = null;
    [HideInInspector] public KillTrackerText killTrackerText = null;

    private int killedEnemies = 0;

    private bool sceneLoadCallbackRegistered = false;

    private void Awake()
    {
        if (gameControllerInstance == null)
        {
            gameControllerInstance = this;
            DontDestroyOnLoad(gameObject);

            if (!sceneLoadCallbackRegistered)
            {
                SceneManager.sceneLoaded += ResetKillCounter;
                sceneLoadCallbackRegistered = true;
            }
        }
        else if (gameControllerInstance != this)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyDied()
    {
        killedEnemies += 1;
        killTrackerText?.DisplayKillcount(killedEnemies);
    }

    public void PlayerDied()
    {
        LoadGameOverScene();
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }

    public int GetKills()
    {
        return killedEnemies;
    }

    private void ResetKillCounter(Scene loadedScene, LoadSceneMode mode)
    {
        if (loadedScene.buildIndex != 2)
        {
            killedEnemies = 0;
        }
    }
}