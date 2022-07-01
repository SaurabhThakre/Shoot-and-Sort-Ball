using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    private GameManager gameManager;

    public AudioClip shootAudio;
    private AudioSource playerAudio;
    public float posY = 8;
    public float posZ = -16;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameActive)
        {
            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                playerAudio.PlayOneShot(shootAudio);
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = new Vector3(0, posY, posZ); // position it at player
            }
        }

    }
}
