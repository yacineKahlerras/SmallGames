using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < player.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
