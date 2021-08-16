using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int _startStarAmount = 100;
    TextMeshProUGUI starText;

    private int starAmount;


    void Start()
    {
        starAmount = Mathf.RoundToInt(_startStarAmount / GameSessionManager.Instance.GetDifficulty());
        starText = GetComponent<TextMeshProUGUI>();
        UpdateStarText();
    }

    private void UpdateStarText()
    {
        starText.text = starAmount.ToString();
    }

    public void AddStars(int amount)
    {
        starAmount += amount;
        UpdateStarText();
    }

    public bool SpendStars(int amount)
    {
        if (starAmount - amount < 0) return false;
        starAmount -= amount;
        UpdateStarText();
        return true;
    }
}
