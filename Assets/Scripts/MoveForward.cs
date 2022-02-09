using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private int multiplier = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * multiplier * Time.deltaTime);
    }
}
