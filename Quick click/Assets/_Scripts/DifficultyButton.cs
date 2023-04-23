 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _button;
    private GameManager gameManager;
    public float difficultyButton;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);

        gameManager = FindObjectOfType<GameManager>();
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficultyButton);
    }
}
