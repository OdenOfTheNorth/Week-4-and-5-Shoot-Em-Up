using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        GameController.GameControllerInstance.LoadMainMenu();
    }

    public void LoadGamePlayScene()
    {
        GameController.GameControllerInstance.LoadGameplayScene();
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}