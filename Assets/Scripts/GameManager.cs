using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    private GameObject ballPosition;
    //private bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        ballPosition = GameObject.FindGameObjectWithTag("Ball");
        restartButton = GetComponent<Button>();
        //restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {   
        if(ballPosition.transform.position.y < -125)
        {

            Debug.Log(ballPosition.transform.position.y);
            titleScreen.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        //isGameActive = false;
        }
    }

    // Restart game by reloading the scene
    void RestartGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
