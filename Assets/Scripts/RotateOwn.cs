using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOwn : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 220 * Time.deltaTime);
    }
}
