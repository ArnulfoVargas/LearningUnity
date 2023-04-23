using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Doble barra es un comentario, barra asterisco hace un comentario prolongado hasta donde llegue el simbolo de cierre
public class PlayerController : MonoBehaviour
{
    /*variables
     * Para estas en c# se necesitan 4 cosas:
     * a)Modificador de acceso (Publico o Privado)
     *   -Una variable publica se puede modificar desde otros  scripts
     *   -Una variable privada solo se puede acceder desde el script en cuestión
     * b)Tipo de dato (int, float, double, char, bool, etc)
     *   -Si es float siempre poner el punto decimal y seguido del numero una f
     * c)Nombre de la variable
     * d)Valor
     * Ej:  Public int gravity = 20
     * 
     * Modificadores
     * Permiten establecer algo adicional sobre las variable y se mencionan entre corchetes []
     * Ej: [HideInInspector] 
     * Para mostrar una variable privada en el modificador de juego es [SerializeField]
    */

    [Range(0,30)] public float speed = 20.0f;
    public float turnSpeed = 30.0f;
    private float horizontalinput;
    private float aceleration;
    void Update()
    {
       
        horizontalinput = Input.GetAxis("Horizontal");
        aceleration = Input.GetAxis("Vertical");
        
        transform.Translate(speed * Time.deltaTime * Vector3.forward * aceleration); 
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalinput );

    }
}
