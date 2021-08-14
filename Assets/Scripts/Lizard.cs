using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (collision.GetComponent<Deffender>())
        {
            GetComponent<Attacker>().Attack(other);
        }
    }
}
