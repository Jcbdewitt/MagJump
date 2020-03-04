using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform Player;

    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = Player.position.y;
        newPosition.x = Player.position.x;
        transform.position = newPosition;
    }
}
