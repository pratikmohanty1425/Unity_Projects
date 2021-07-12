using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdestination : MonoBehaviour
{
    public Vector2 startpos;

    void Start()
    {
        playermovement.player.transform.position = transform.position;
        playermovement.player.lastpos = startpos;

        camerafollower.cam.transform.position =
            new Vector3(transform.position.x, transform.position.y,
            transform.position.z);
    }

}
