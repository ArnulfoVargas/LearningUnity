using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    //OnTriggerEnter se activara al entrar en contacto el trigger del gameObject con otro objeto fisico 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectile"))
        {
            Destroy(this.gameObject); //Destruye el proyectil
            Destroy(other.gameObject); // Destruye el enemigo
        }
    }
}
