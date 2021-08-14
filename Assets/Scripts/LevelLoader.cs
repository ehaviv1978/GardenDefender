using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 4f;

    public static LevelLoader Instance;

    private int previusSceneIndex = 0;

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


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
           Invoke(nameof(LoadNextScene), loadDelay);
        }
    }

    public void LoadNextScene()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel1()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene("Level 1");
    }


    public void LoadMainMenu()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene(1);
    }

    public void LoadEndScene()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void RestartScene()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadOptionMenu()
    {
        SetPreviousSceneIndex();
        SceneManager.LoadScene("Option Menu");
    }


    public void LoadPreviousScene()
    {
        print("Hi");
        //SetPreviousSceneIndex();
        SceneManager.LoadScene(previusSceneIndex);
    }

    private void SetPreviousSceneIndex()
    {
        previusSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
