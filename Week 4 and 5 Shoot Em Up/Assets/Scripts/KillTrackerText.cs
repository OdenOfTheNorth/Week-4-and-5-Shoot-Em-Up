using UnityEngine;
using UnityEngine.UI;

public class KillTrackerText : MonoBehaviour
{
    private Text killText = null;

    private void Awake()
    {
        killText = GetComponent<Text>();
        GameController.GameControllerInstance.killTrackerText = this;
        DisplayKillcount(0);
    }

    public void DisplayKillcount(int kills)
    {
        killText.text = "Kills: " + kills;
    }
}