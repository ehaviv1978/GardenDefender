using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float currentSpeed = 1f;
    Animator animator;
    GameObject currentTarget;

    public static event Action<Attacker> AttackerSpawned;
    public static event Action<Attacker> AttackerDestroyed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        AttackerSpawned?.Invoke(this);
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        CheckTarget();
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }


    public void Attack(GameObject target)
    {
        currentTarget = target;
        animator.SetBool("IsAttacking", true);
    }


    public void DamageTarget(int damage)
    {
        if (!currentTarget) return;
        currentTarget.GetComponent<Health>().TakeDamage(damage);
    }

    public void CheckTarget()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void OnDestroy()
    {
        AttackerDestroyed?.Invoke(this);
    }
}
