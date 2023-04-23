using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _objects;
    private float minForce = 9.5f;
    private float maxForce = 14.2f;
    private float torqueForce = 17.5f;
    private float xPos = 4.5f;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosion;

    void Start()
    {
        _objects = GetComponent<Rigidbody>();
        _objects.AddForce(RandomForce(), ForceMode.Impulse);
        _objects.AddTorque(TorqueForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// genera una fuerza vertical aleatoria para impulsar a los objetos
    /// </summary>
    /// <returns>regresa una fuerza aleatoria</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    /// <summary>
    /// Genera una pocision aleatoria en x y mantiene y en -1
    /// </summary>
    /// <returns>regresa una posición x aleatoria y una y establecida</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xPos, xPos), -1);
    }

    /// <summary>
    /// Genera un vector 3 aleatorio para aplicarlo en el torque de los objetos
    /// </summary>
    /// <returns>Regresa un vector 3 aleatorio</returns>
    private Vector3 TorqueForce()
    {
        return new Vector3(Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce));
    }

    private void OnMouseDown()
    {
        if (gameManager.gameState== GameManager.GameState.inGame)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.UpdateScore(pointValue);

            if (gameObject.CompareTag("Bomb"))
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deadzone"))
        {
            Destroy(this.gameObject);
            if (gameObject.CompareTag("Food"))
            {
                gameManager.GameOver();
            }
        }
    }
}
