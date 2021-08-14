using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackers;
    [SerializeField] float minSpawnInterval = 1f;
    [SerializeField] float maxSpawnInterval = 3f;

    bool isSpawning = true;


    void Start()
    {
        StartCoroutine(nameof(SpawnDellay));
    }


    //call enemy spawner in random intervals in delay range
    IEnumerator SpawnDellay()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            SpawnEnemy(GetRandomAttacker());
        }
    }


    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(nameof(SpawnDellay));
    }

    //return random 'Attacker' from 'attackers' arry
    private Attacker GetRandomAttacker()
    {
        return attackers[Random.Range(0, attackers.Length)];
    }

    //spawn attacker as spawner location, make attacker child object of spawner
    private void SpawnEnemy(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
