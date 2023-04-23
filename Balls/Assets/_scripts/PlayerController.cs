using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float force = 10;
    private Rigidbody _player;
    private GameObject focalPoint;

    public bool powerUpActive;
    public float powerUpForce = 20;
    public GameObject[] powerUpIndicators;
    private float powerUpTime = 6.0f;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        _player.AddForce(focalPoint.transform.forward * force * verticalInput);

        foreach(GameObject indicators in powerUpIndicators )
        {
            indicators.transform.position = this.transform.position + 0.7f*Vector3.down;
        }
        if (this.transform.position.y < -5)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powerUpActive = true;
            StartCoroutine("powerUpCountdown");
            powerUpIndicators[0].SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (powerUpActive == true)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - this.transform.position;

            enemyRigidBody.AddForce(awayDirection * powerUpForce, ForceMode.Impulse);

        }
    }
    IEnumerator powerUpCountdown()
    {
        for (int i = 0; i < powerUpIndicators.Length; i++ )
        {

            powerUpIndicators[i].SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            powerUpIndicators[i].SetActive(false);
            
        }
        powerUpActive = false;
    }
}