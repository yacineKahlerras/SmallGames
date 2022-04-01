using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int speed = 100;
    public float rightLimit, leftLimit;
    Vector3 target;
    public bool movingRight = true;

    public List<Transform> quads, quadReturnPoints;

    private void Start()
    {
        target = transform.position;
        if (movingRight)
        {
            target.x = rightLimit;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            target.x = leftLimit;
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < quads.Count; i++)
        {
            if(quads[i].position == target)
            {
                quads[i].position = quadReturnPoints[i].position;
            }

            quads[i].position = Vector3.MoveTowards(quads[i].position, target, speed * Time.deltaTime);
        }
    }
}
