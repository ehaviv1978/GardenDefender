using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        LevelLoader.Instance.LoadMainMenu();
    }
}
