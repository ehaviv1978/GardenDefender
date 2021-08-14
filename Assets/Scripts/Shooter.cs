using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner[] spawners;
    AttackerSpawner laneSpawner;
    Animator animator;

    private void Start()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }


    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    void SetLaneSpawner()
    {
        foreach(AttackerSpawner spawner in spawners)
        {
            if(Mathf.Round(spawner.transform.position.y) == Mathf.Round(transform.position.y))
            {
                laneSpawner = spawner;
            }
        }
    }


    private bool IsAttackerInLane()
    {
        if (laneSpawner.transform.childCount > 0) return true;
        return false;
    }


    public void Fire()
    {
        var proj = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
