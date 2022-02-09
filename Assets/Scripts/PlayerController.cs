using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed;
    private int multiplier = 200;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * multiplier * speed *
        forwardInput * Time.deltaTime);
        powerupIndicator.transform.position = transform.position;
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&
       hasPowerup)
        {
            Rigidbody enemyRb =
           collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =
           (collision.gameObject.transform.position - transform.position);
            Debug.Log("Player collided with " +
           collision.gameObject + " with powerup set to " +
           hasPowerup);
            enemyRb.AddForce(awayFromPlayer *
           powerupStrength, ForceMode.Impulse);
        }
    }
}
