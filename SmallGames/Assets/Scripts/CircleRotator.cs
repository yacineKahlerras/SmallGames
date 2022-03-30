using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Transform rotatableObject;

    // Update is called once per frame
    void Update()
    {
        rotatableObject.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
