using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed;
    private int multiplier = 200;
    public bool hasPowerup;
    public int activePowerup = 1;
    public GameObject projectilePrefab;
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
        string[] sub = other.gameObject.tag.ToString().Split('_');
        //Debug.Log(sub[0]);
        if (sub[0] == "powerup")
        {
            Destroy(other.gameObject);
            activePowerup = int.Parse(sub[1]);

            if (activePowerup == 1)
            {
                hasPowerup = true;
                StartCoroutine(PowerupCountdownRoutine());
                powerupIndicator.gameObject.SetActive(true);

            }
            if (activePowerup == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    Instantiate(projectilePrefab, transform.position,
                       Quaternion.Euler(new Vector3(0, 45f * i, 0))).transform.Translate(Vector3.forward * 2);
                }

            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&
       hasPowerup && activePowerup == 1)
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
