using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOutOfBounds : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 18 || Mathf.Abs(transform.position.z) > 18)
        {
            Object.Destroy(gameObject);
        }
    }
}
