using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Counter ballCounter;
    private GameManager gameManager;

    public AudioClip destructionAudio;
    private AudioSource playerAudio;

    public ParticleSystem fireworkParticle;

    void Start()
    {
        ballCounter = GameObject.Find("Boxes").GetComponent<Counter>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(fireworkParticle, transform.position, fireworkParticle.transform.rotation);
        if (gameManager.isGameActive)
        {
            if (!other.CompareTag("enemy_ball"))
            {
                playerAudio.PlayOneShot(destructionAudio);
                ballCounter.Life--;
                ballCounter.LifeText.text = "Life : " + ballCounter.Life;
                if (ballCounter.Life == 0)
                {
                    gameManager.GameOver();
                }
            }

            gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

}
