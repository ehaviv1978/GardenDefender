using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLives : MonoBehaviour
{
    LifeManager liveManager;
    TextMeshProUGUI textLivesLeft;

    void Start()
    {
        textLivesLeft = FindObjectOfType<TextMeshProUGUI>();
        liveManager = FindObjectOfType<LifeManager>();
        ChangeLifeShown();
    }

    public void ChangeLifeShown()
    {
        textLivesLeft.text = liveManager.GetLivesLeft().ToString();
    }
}
