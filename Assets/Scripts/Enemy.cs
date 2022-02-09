using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip muerte1;
    public AudioClip muerte2;
    private AudioSource enemyAudio;
    private float speed = 10f;
    Rigidbody enemyRb;
    GameObject player;
    private bool alife = true;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 moveDirection = (player.transform.position
        - transform.position).normalized;
        enemyRb.AddForce(moveDirection * speed * 100 * Time.deltaTime);
        if (transform.position.y < -1.5f)
        {
            if (alife)
            {
                enemyAudio.PlayOneShot(muerte2, 1.0f);
                StartCoroutine(SetDead());
            }
        }
    }
    IEnumerator SetDead()
    {
        alife = false;

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            //Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            //Debug.Log("proyectil muerto");

            if (alife)
            {
                enemyAudio.PlayOneShot(muerte1, 1.0f);
                StartCoroutine(SetDead());
            }
        }
    }
}
