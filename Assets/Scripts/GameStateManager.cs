using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private float audioVolume = 0.5f;
    private int difficultyLevel = 1;

    public static GameStateManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float value)
    {
        audioVolume = value;
    }

    public void SetDifficulty(int value)
    {
        difficultyLevel = value;
    }
}
