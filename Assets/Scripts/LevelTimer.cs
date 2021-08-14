using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [Tooltip("Set levle timer in seconds.")]
    [Range(10,1000)]
    [SerializeField] private float _startLevelTime = 10f;

    public static event Action LevelTimeEnded;

    private Slider sliderLevelTimer;

    private bool isLevelEnded = false;


    private void Start()
    {
        sliderLevelTimer = GetComponent<Slider>();
    }

   
    void Update()
    {
        if (isLevelEnded) return;

        sliderLevelTimer.value = Time.timeSinceLevelLoad / _startLevelTime;

        if( Time.timeSinceLevelLoad >= _startLevelTime)
        {
            LevelTimeEnded?.Invoke();
            isLevelEnded = true;
        }
    }

}
