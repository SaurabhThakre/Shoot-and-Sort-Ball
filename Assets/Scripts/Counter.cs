using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public Text ScoreText;
    public Text LifeText;

    private GameManager gameManager;

    private int Count = 0;
    private int c_small = 0;
    private int c_medium = 0;
    private int c_large = 0;
    private int Score = 0;
    public int Life = 3;

    public AudioClip celebrateAudio;
    public AudioClip destructionAudio;
    private AudioSource playerAudio;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("enemy_ball")){
            playerAudio.PlayOneShot(celebrateAudio);
            Count++;
            CounterText.text = "Count : " + Count;

            if (other.CompareTag("box_small"))
            {
                Score += 5;
                c_small++;
                if (c_small > 8)
                {
                    Destroy(other.gameObject);
                }
            }
            else if (other.CompareTag("box_medium"))
            {
                Score += 10;
                c_medium++;
                if (c_medium > 4)
                {
                    Destroy(other.gameObject);
                }
            }
            else if (other.CompareTag("box_large"))
            {
                Score += 15;
                c_large++;
                if (c_large > 1)
                {
                    Destroy(other.gameObject);
                }
            }
            ScoreText.text = "Score : " + Score;
        }
        else
        {
            playerAudio.PlayOneShot(destructionAudio);
            Life--;
            LifeText.text = "Life : " + Life;
            if(Life == 0)
            {
                gameManager.GameOver();
            }
        }
        
    }
}
