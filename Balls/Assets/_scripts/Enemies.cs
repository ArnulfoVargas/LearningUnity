using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float force = 10;
    private Rigidbody _enemy;
    private GameObject _focalPoint;

    void Start()
    {
        _focalPoint = GameObject.Find("Player");
        _enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (_focalPoint.transform.position - this.transform.position).normalized;
        _enemy.AddForce(direction * force);

        if (this.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
    }
}
