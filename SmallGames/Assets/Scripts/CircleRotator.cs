using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
