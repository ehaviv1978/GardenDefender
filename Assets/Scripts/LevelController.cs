using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject canvasLevelComplete;
    [SerializeField] GameObject canvasGameLost;

    private List<Attacker> attackersInLevel = new List<Attacker>();


    private LifeManager lifeManager;
    private bool isTimeEnded = false;


    void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>();
        Attacker.AttackerSpawned += AddAttacker;
        Attacker.AttackerDestroyed += RemoveAttacker;
        LevelTimer.LevelTimeEnded += TimeEnded;
        canvasLevelComplete.SetActive(false);
        canvasGameLost.SetActive(false);
        LifeManager.ZeroLife += LevelLost;
    }

    void Update()
    {
        
    }

    private void TimeEnded()
    {
        isTimeEnded = true;
        
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }

        if (attackersInLevel.Count == 0 && lifeManager.GetLivesLeft() > 0)
        {
            LevelWon();
        }
    }


    private void AddAttacker(Attacker attacker)
    {
        attackersInLevel.Add(attacker);
    }


    private void RemoveAttacker(Attacker attacker)
    {
        attackersInLevel.Remove(attacker);

        if (attackersInLevel.Count == 0 && isTimeEnded && lifeManager.GetLivesLeft() > 0)
        {
            LevelWon();
        }
    }

    private void LevelWon()
    {
        StartCoroutine(nameof(HandleLevleComplete));
    }


    private void LevelLost()
    {
        Time.timeScale = 0;
        canvasGameLost.SetActive(true);
    }

    IEnumerator HandleLevleComplete()
    {
        canvasLevelComplete.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        LevelLoader.Instance.LoadNextScene();
    }

    private void OnDestroy()
    {
        Attacker.AttackerSpawned -= AddAttacker;
        Attacker.AttackerDestroyed -= RemoveAttacker;
        LevelTimer.LevelTimeEnded -= TimeEnded;
        LifeManager.ZeroLife -= LevelLost;
    }
}
