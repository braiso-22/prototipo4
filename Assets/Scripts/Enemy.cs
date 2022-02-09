using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    Rigidbody enemyRb;
    GameObject player;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }



    void Update()
    {
        Vector3 moveDirection = (player.transform.position
        - transform.position).normalized;
        enemyRb.AddForce(moveDirection * speed);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
