using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int _startLives = 10;
    [SerializeField] TextMeshProUGUI textHealth;

    public static event Action ZeroLife;

    int livesLeft;


    private void Awake()
    {
        livesLeft = _startLives;
    }


    private void Start()
    {
        Boarder.EnemyEnter += ReduceLive;
        UpdateHealthText();
    }


    public int GetLivesLeft()
    {
        return livesLeft;
    }

    public void ReduceLive()
    {
        livesLeft = Mathf.Max(0, livesLeft-1);
        UpdateHealthText();
        if(livesLeft == 0)
        {
            Invoke(nameof(NoLifeLeft), 0f);
        }
    }


    private void NoLifeLeft()
    {
        print("hi");
        ZeroLife?.Invoke();
    }

    private void UpdateHealthText()
    {
        textHealth.text = livesLeft.ToString();
    }

    private void OnDestroy()
    {
        Boarder.EnemyEnter -= ReduceLive;
    }
}
