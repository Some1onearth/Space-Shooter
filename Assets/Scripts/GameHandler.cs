using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public GameObject enemy, retryButton, quitButton;
    [SerializeField] public int hiScore = 0;
    [SerializeField] public int currentScore = 0;
    [SerializeField] Text currentScoreCounter;
    [SerializeField] Text hiScoreCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameHandler == null)
        {
            gameHandler = this;
        }
        else
        {
            Destroy(this);
            Debug.LogWarning("Second GameHandler");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score()
    {
        currentScore += 1;
        currentScoreCounter.text = "" + currentScore;
        PlayerPrefs.SetInt("Score", currentScore);
    }
    public void HiScore()
    {
        if (PlayerPrefs.GetInt("HiScore", 0) <= currentScore)
        {
            PlayerPrefs.SetInt("HiScore", currentScore);
        }
        
        hiScoreCounter.text = "Hi-Score " + PlayerPrefs.GetInt("HiScore");
    }
    public void Buttons()
    {
        retryButton.SetActive(true);
        quitButton.SetActive(true);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0); // exits the game
    }
    public void ExitTheGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit(); //quits game within Unity as well
    }
}
