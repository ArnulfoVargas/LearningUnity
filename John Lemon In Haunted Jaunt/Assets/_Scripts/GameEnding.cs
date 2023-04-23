using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 3.0f;
    private bool isPlayerAtExit, isPlayerCaught;
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            isPlayerAtExit = true;
        }
    }
    private void Update()
    {
        if (isPlayerAtExit == true)
        {
            EndLevel(exitBackground, false, exitAudio);
        }
        else if (isPlayerCaught == true)
        {
            EndLevel(CaughtBackground, true, caughtAudio);
        }

    }


    public CanvasGroup exitBackground;
    public CanvasGroup CaughtBackground;
    private float timer = 0;
    public AudioSource exitAudio, caughtAudio;
    private bool hasAudioPlayed;


    /// <summary>
    /// Metodo que modifica el alfa del canvas group dado para el final del juego y termina cerrando la aplicación 
    /// </summary>
    /// <param name="ExitImage"> Una variable de tipo Canvas Group </param>
    void EndLevel(CanvasGroup ExitImage, bool restart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        ExitImage.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);
        if (timer > fadeDuration)
        {
            if (restart == false)
            {
                Application.Quit();
                Debug.Log("Se ha cerrado");
            }
            else if (restart == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void catchPlayer()
    {
        isPlayerCaught = true;
    }
}
