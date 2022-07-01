using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI finalScoreText;
    public Button startButton;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject gameScreen;
    public GameObject gameOverScreen;

    public AudioClip gameoverAudio;
    private AudioSource playerAudio;

    private Counter ballCounter;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        ballCounter = GameObject.Find("Boxes").GetComponent<Counter>();
        playerAudio = GetComponent<AudioSource>();
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        playerAudio.Stop();
        playerAudio.PlayOneShot(gameoverAudio);
        gameOverScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
        isGameActive = false;
        finalScoreText.text = ballCounter.CounterText.text + "     " + ballCounter.ScoreText.text;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        playerAudio.enabled = !playerAudio.enabled;
    }

}
