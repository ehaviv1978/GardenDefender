using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenderButton : MonoBehaviour
{
    [SerializeField] Deffender deffenderPrefab;
    [SerializeField] Color darkColor;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DeffenderButton>();
        
        foreach(DeffenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = darkColor;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DeffenderSpawner>().SetDeffender(deffenderPrefab);
    }
}
