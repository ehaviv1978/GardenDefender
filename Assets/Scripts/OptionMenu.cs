using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Slider sliderDifficulty;
    [SerializeField] [Range(0,1)] private float defaultVolume = 0.5f;
    [SerializeField] [Range(1,5)] private int defaultDifficulty = 1;


    private void Start()
    {
        sliderVolume.value = GameSessionManager.Instance.GetVolume();
        sliderDifficulty.value = GameSessionManager.Instance.GetDifficulty();
    }


    public void BackToDefult()
    {
        sliderVolume.value = defaultVolume;
        sliderDifficulty.value = defaultDifficulty;
    }


    public void SetVolume()
    {
        GameSessionManager.Instance.SetVolume(sliderVolume.value);
    }

    public void SetDifficulty()
    {
        GameSessionManager.Instance.SetDifficulty(Mathf.RoundToInt(sliderDifficulty.value));
    }

    public void BackToPreviousScene()
    {
        LevelLoader.Instance.LoadPreviousScene();
    }

}
