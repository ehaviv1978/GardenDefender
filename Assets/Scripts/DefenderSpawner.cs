using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;
    private GameObject defenderPerent;

    private const string DEFFENDER_PERENT_NAME = "Defenders";


    private void Start()
    {
        CreateDefenderPerent();
    }

    private void CreateDefenderPerent()
    {
        defenderPerent = GameObject.Find(DEFFENDER_PERENT_NAME);
        if (defenderPerent == null)
        {
            defenderPerent = new GameObject(DEFFENDER_PERENT_NAME);
        }
    }


    private void OnMouseDown()
    {
        if (!defender) return;
        AttemptToSpwanDeffenderAt(GetSquerClicked());
    }

    private Vector2 GetSquerClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y);
        return worldPos;
    }


    private void AttemptToSpwanDeffenderAt(Vector2 location)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int starCost = defender.GetStarCost();
        if (starDisplay.SpendStars(starCost))
        {
            SpawnDeffender(location);
        }
    }


    public void SetDeffender(Defender selectedDeffender)
    {
        defender = selectedDeffender;
    }


    private void SpawnDeffender(Vector2 position)
    {
        var newDeffender = Instantiate(defender, position, Quaternion.identity) as Defender;
        newDeffender.transform.parent = defenderPerent.transform;
    }
}
