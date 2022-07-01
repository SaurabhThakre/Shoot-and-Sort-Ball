using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrop : MonoBehaviour
{

    Rigidbody playerRb;
    int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.velocity.magnitude == 0 && flag == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            flag = 1;
        }
    }

}
