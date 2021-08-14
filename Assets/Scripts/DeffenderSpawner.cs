using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenderSpawner : MonoBehaviour
{
   Deffender deffender;


    private void OnMouseDown()
    {
        if (!deffender) return;
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
        int starCost = deffender.GetStarCost();
        if (starDisplay.SpendStars(starCost))
        {
            SpawnDeffender(location);
        }
    }


    public void SetDeffender(Deffender selectedDeffender)
    {
        deffender = selectedDeffender;
    }


    private void SpawnDeffender(Vector2 position)
    {
        var newDeffender = Instantiate(deffender, position, Quaternion.identity) as Deffender;
    }
}
