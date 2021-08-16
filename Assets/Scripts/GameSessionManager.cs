using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    private float volumeLevel = 0.5f;
    private int difficultyLevel = 1;

    public static GameSessionManager Instance;

    private const string KEY_MASTER_VOLUME_LEVEL = "Volume Level";
    private const string KEY_DIFFICULTY_LEVEL = "Difficulty Level";

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

    private void Start()
    {
        volumeLevel = PlayerPrefs.GetFloat(KEY_MASTER_VOLUME_LEVEL, 0.5f);
        difficultyLevel = PlayerPrefs.GetInt(KEY_DIFFICULTY_LEVEL, 1);
        SetGameVolumeLevel();
    }

    private void SetGameVolumeLevel()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        if (audioSources.Length == 0) return;
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.volume = volumeLevel;
        }
    }


    public void SetVolume(float value)
    {
        volumeLevel = value;
        SetGameVolumeLevel();
        PlayerPrefs.SetFloat(KEY_MASTER_VOLUME_LEVEL, value);
    }

    public void SetDifficulty(int value)
    {
        difficultyLevel = value;
        PlayerPrefs.SetInt(KEY_DIFFICULTY_LEVEL, value);
    }

    public float GetVolume()
    {
        return volumeLevel;
    }

    public int GetDifficulty()
    {
        return difficultyLevel;
    }
}
