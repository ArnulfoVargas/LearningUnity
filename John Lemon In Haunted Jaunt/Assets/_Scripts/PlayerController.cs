using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 movement;
    private Animator _animator;
    private float turnSpeed = 20;
    private Rigidbody _player;
    private Quaternion rotation = Quaternion.identity;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        /* Se settea la variable de tipo Vector 3 movimiento referente a horizontal y vertical input, a continuacion se normaliza para
         * en diagonales no supere el 1
         */
        movement.Set(horizontalInput, 0, verticalInput);
        movement.Normalize();

        /* se crea la variable IsWalking, esta es true si alguna de las variables booleanas hasHorizontalInput o hasVerticalInput
         * son true, dichas variables toman en el eje horizontal y vertical ( que normalmente son floats ) y se convierten a booleanos 
         * gracias a la funcion de matematica de aproximacion, asi si horizonta o vertical input se asemejan a 0, daran una señal 
         * falsa
         */
        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if (isWalking)
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }
        else
        {
            _audio.Stop();
        }

        // se activa el booleano IsWalking del player animator para ejecutar la animacion
        _animator.SetBool("IsWalking", isWalking);

        /*Se crea la Variable Desired Forward que es igual a girar hacia el forward del transform, en direcciion de la variable movement
         * regulado por time delta time por la variable de turn speed y al final se asigna una magnitud maxima
         */

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, Time.deltaTime * turnSpeed, 0f);

        /*
         * se reestablece el valor de la variable rotation que anterior era quaternion.identity que toma la rotacion base del prefab
         * y se dice que la direccion a observar que va a bakear es la dada por la variable desired forward
         */
        rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        //espacio = PosicionInicial + (Velocidad * Tiempo)
        _player.MovePosition(_player.position + movement * _animator.deltaPosition.magnitude);
        _player.MoveRotation(rotation);
    }
}
