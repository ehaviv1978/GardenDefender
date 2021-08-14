using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deffender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStar(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
