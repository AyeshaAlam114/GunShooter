using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyParent;

    public Transform[] spawnPositions;

    public int spawnRange;
    public float spawnPositionRange;




    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

   

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
            SpawnEnemy(i);
    }
    public void SpawnEnemy(int i)
    {
        GameObject spawnedEnemy=Instantiate(enemyPrefab, spawnPositions[i].position, Quaternion.identity, spawnPositions[i].transform);
        spawnedEnemy.GetComponent<EnemyController>().SetSpawnManager(this);
    }

 
}
