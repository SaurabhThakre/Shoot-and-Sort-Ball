using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] ballPrefabs;
    public float spawnPosX = 0;
    public float spawnPosY = 30;
    public float spawnPosZ = -18;
    private float startDelay = 2;
    private float spawnInterval = 4f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomBall()
    {
        if (gameManager.isGameActive) {
            int ballIndex = Random.Range(0, ballPrefabs.Length);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        }
        
    }

}
