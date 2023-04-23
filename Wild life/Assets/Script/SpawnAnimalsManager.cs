using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnAnimalsManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;
    private float spawnRangeX = 15;
    private float spawnZ;
    private float startDelay = 2.0f;
    private float spawnTime = 1.0f;

    private void Start()
    {
        spawnZ = this.transform.position.z;
        //InvokeReapeting sirve para invocar una funcion repetidamente, Invoke es solo para invocarla sin repeticion
        InvokeRepeating("RandSpawn" , startDelay, spawnTime);
    }

    //Genero una funcion que se encarge de spawnear enemigos
    private void RandSpawn()
    {
        //La pocision en vector 3 la convierto en una variable
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZ);
        //genero un animal en posicion aleatoria
        animalIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[animalIndex], spawnpos,
        enemies[animalIndex].transform.rotation);

    }
}
