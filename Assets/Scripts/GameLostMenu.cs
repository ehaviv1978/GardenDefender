using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLostMenu : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1;
        LevelLoader.Instance.RestartScene();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        LevelLoader.Instance.LoadMainMenu();
    }
}
