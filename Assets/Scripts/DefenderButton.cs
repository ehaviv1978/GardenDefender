using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    [SerializeField] Color darkColor;


    private void Start()
    {
        SetTextCost();
    }

    private void SetTextCost()
    {
        Text textCost = GetComponentInChildren<Text>();
        if (textCost == null)
        {
            Debug.Log("No cost text component found in: " + name);
        }
        else
        {
            textCost.text = defenderPrefab.GetStarCost().ToString();
        }
    }


    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = darkColor;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetDeffender(defenderPrefab);
    }
}
