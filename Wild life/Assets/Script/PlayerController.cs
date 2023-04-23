using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float HorizontalInput;
    public float speed = 10 ;
    public float xrange = 16.0f;
    public GameObject proyectilePrefab;
    private float startShoot = 0f;
    private float delay = 0.1f;

    private void Start()
    {
        InvokeRepeating("shoot", startShoot, delay);
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        //s=v*t
        transform.Translate(Vector3.right * speed * Time.deltaTime * HorizontalInput);
        //se limita al granjero a un rango de posicion
        if (transform.position.x > xrange)
        {
            transform.position = new Vector3(xrange, transform.position.y, transform.position.z);

        }
        if (transform.position.x < -xrange)
        {
            transform.position = new Vector3(-xrange, transform.position.y, transform.position.z);
        }
        /*El get key da un valor booleano, a diferencia del get axis que da un float, tambien existe get key down que
         * es mantener pulsado y get key up que es al soltar
         */
        
        Debug.Log(Time.deltaTime);
    }
    
    private void shoot()
    {

    
       if (Input.GetKey(KeyCode.Space))
       {
          // si se activa, se tiene que lanzar el proyectil
          Instantiate(proyectilePrefab, transform.position, proyectilePrefab.transform.rotation);

       }
       
    }
}
