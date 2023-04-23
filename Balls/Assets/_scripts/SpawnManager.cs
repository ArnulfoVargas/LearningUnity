using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public float spawnRange= 8;
    public GameObject enemyPrefab;
    private int enemyCount;
    private int enemyWave = 1;
    public GameObject powerUp;

    private void Start()
    {
        SpawnWave(enemyWave);
    }
    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnWave(enemyWave);
            Instantiate(powerUp, RandomSpawnZone(), powerUp.transform.rotation);
        }
    }
    /// <summary>
    /// Genera una posicion aleatoria en x y z
    /// </summary>
    /// <returns>Devuelve una pocision aleatoria</returns>
    private Vector3 RandomSpawnZone()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 enemiesSpawn = new Vector3(spawnPosX, 0, spawnPosZ);

        return enemiesSpawn;
    }

    /// <summary>
    /// Este metodo genera una oleada de enemigos en pantalla
    /// <paramref name="iSpawnValue"/>Número de enemigos en la oleada<
    /// </summary>
    public void SpawnWave(int iSpawnValue)
    {
        for (int i = 0; i<iSpawnValue; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnZone(), enemyPrefab.transform.rotation);
        }
        iSpawnValue = iSpawnValue++;
    }
}
