using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class SpawnerEnemy : MonoBehaviour
{
    [Tooltip("SO_CurrentLevel")] public SO_CurrentLevel levelInfo;
    [Tooltip("The order in which the enemies are spawned")] public List<GameObject> enemyPrefabs = new();
    [Tooltip("The interval between enemies spawning")] public float interval = 10f;
    [Tooltip("List of spawning positions for the enemies of this type")] public List<Transform> enemy0SpawnersList = new();
    [Tooltip("List of spawning positions for the enemies of this type")] public List<Transform> enemy1SpawnersList = new();
    [Tooltip("List of spawning positions for the enemies of this type")] public List<Transform> enemy2SpawnersList = new();
    [Tooltip("List of spawning positions for the enemies of this type")] public List<Transform> enemy3SpawnersList = new();
    [Tooltip("List of spawning positions for the enemies of this type")] public List<Transform> enemy4SpawnersList = new();
    [Tooltip("Reference to the Animation Timeline object")] public GameObject timeline;
    private readonly float timeBeforeFirst = 48f; // The duration of the cutscene

    void Start()
    {
        levelInfo.enemiesInLevel.Clear();
        StartCoroutine(LoopSpawning());
    }

    private IEnumerator LoopSpawning()
    {
        if (timeline.activeSelf == true) // If the animation is enabled, the script waits before spawning the first enemy
        {
            yield return new WaitForSeconds(timeBeforeFirst);
        }

        int index = 0; // Start at the beginning of the list
        int randomValue;

        while (true)
        {
            if (enemyPrefabs.Count == 0)
            {
                yield break; // Exit coroutine if the list is empty
            }

            GameObject currentEnemy = enemyPrefabs[index];
            EnemyGeneric enemyScript = currentEnemy.GetComponent<EnemyGeneric>();
            EnemyType enemyType = enemyScript.type;
            GameObject instantiatedEnemy = null; 
            switch (enemyType)
            {
                case EnemyType.enemy0:
                    if (enemy0SpawnersList.Count == 0) { yield break; }
                    randomValue = Random.Range(0, enemy0SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy0SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy1:
                    if (enemy1SpawnersList.Count == 0) { yield break; }
                    randomValue = Random.Range(0, enemy1SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy1SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy2:
                    if (enemy2SpawnersList.Count == 0) { yield break; }
                    randomValue = Random.Range(0, enemy2SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy2SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy3:
                    if (enemy3SpawnersList.Count == 0) { yield break; }
                    randomValue = Random.Range(0, enemy3SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy3SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy4:
                    if (enemy4SpawnersList.Count == 0) { yield break; }
                    randomValue = Random.Range(0, enemy4SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy4SpawnersList[randomValue]);
                    break;

            }
            levelInfo.enemiesInLevel.Add(instantiatedEnemy);

            // Increment the index and wrap around if necessary
            index = (index + 1) % enemyPrefabs.Count;

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

        }
    }
}
