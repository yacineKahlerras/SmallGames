using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int speed = 100;
    public float rightLimit, leftLimit;
    Vector3 target;
    public bool movingRight = true;

    private void Start()
    {
        target = transform.position;
        if (movingRight) target.x = rightLimit;
        else target.x = leftLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == target)
        {
            if (movingRight)
            {
                target.x = leftLimit;
                movingRight = false;
            }
            else
            {
                target.x = rightLimit;
                movingRight = true;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
