using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text elapsedTime;

    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        elapsedTime.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }
}
