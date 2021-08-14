using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boarder : MonoBehaviour
{
    public static event Action EnemyEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        EnemyEnter?.Invoke();
    }
}
