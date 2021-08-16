using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (collision.GetComponent<Defender>())
        {
            if (collision.GetComponent<GraveStone>())
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
            }
            else
            {
                GetComponent<Attacker>().Attack(other);
            }
        }
    }
}
