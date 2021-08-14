using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void LoadOptionMenu()
    {
        LevelLoader.Instance.LoadOptionMenu();
    }

    public void StarGame()
    {
        LevelLoader.Instance.LoadLevel1();
    }
}
