using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class SpawnerEnemy : MonoBehaviour
{
    public SO_CurrentLevel levelInfo;
    public List<GameObject> enemyPrefabs = new();
    public float interval = 10f;
    public List<Transform> enemy0SpawnersList = new();
    public List<Transform> enemy1SpawnersList = new();
    public List<Transform> enemy2SpawnersList = new();
    public List<Transform> enemy3SpawnersList = new();
    public List<Transform> enemy4SpawnersList = new();

    void Start()
    {
        levelInfo.enemiesInLevel.Clear();
        StartCoroutine(LoopSpawning());
    }

    private IEnumerator LoopSpawning()
    {
        yield return new WaitForSeconds(20f);

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
                    randomValue = UnityEngine.Random.Range(0, enemy0SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy0SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy1:
                    if (enemy1SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy1SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy1SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy2:
                    if (enemy2SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy2SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy2SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy3:
                    if (enemy3SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy3SpawnersList.Count);
                    instantiatedEnemy = Instantiate(currentEnemy, enemy3SpawnersList[randomValue]);
                    break;
                case EnemyType.enemy4:
                    if (enemy4SpawnersList.Count == 0) { yield break; }
                    randomValue = UnityEngine.Random.Range(0, enemy4SpawnersList.Count);
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
