using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class SpawnerEnemy : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new();
    public float interval = 10f;
    public List<Transform> enemy0SpawnersList = new();
    public List<Transform> enemy1SpawnersList = new();
    public List<Transform> enemy2SpawnersList = new();
    public List<Transform> enemy3SpawnersList = new();
    public List<Transform> enemy4SpawnersList = new();

    void Start()
    {
        StartCoroutine(LoopSpawning());
    }

    private IEnumerator LoopSpawning()
    {
        int index = 0; // Start at the beginning of the list
        int randomValue;

        while (true)
        {

            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            if (enemyPrefabs.Count == 0)
            {
                yield break; // Exit coroutine if the list is empty
            }

            GameObject currentEnemy = enemyPrefabs[index];
            EnemyGeneric enemyScript = currentEnemy.GetComponent<EnemyGeneric>();
            EnemyType enemyType = enemyScript.type;
            switch (enemyType)
            {
                case EnemyType.enemy0:
                    if (enemy0SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy0SpawnersList.Count);
                    Instantiate(currentEnemy, enemy0SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy1:
                    if (enemy1SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy1SpawnersList.Count);
                    Instantiate(currentEnemy, enemy1SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy2:
                    if (enemy2SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy2SpawnersList.Count);
                    Instantiate(currentEnemy, enemy2SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy3:
                    if (enemy3SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy3SpawnersList.Count);
                    Instantiate(currentEnemy, enemy3SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy4:
                    if (enemy4SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy4SpawnersList.Count);
                    Instantiate(currentEnemy, enemy4SpawnersList[randomValue]);
                    break;

            }

            // Increment the index and wrap around if necessary
            index = (index + 1) % enemyPrefabs.Count;

        }
    }
}
