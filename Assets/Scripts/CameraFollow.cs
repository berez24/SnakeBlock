using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth = 5.0f;
    public Vector3 lerpY = new Vector3(0, 3, -7);

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + lerpY, Time.deltaTime * smooth);
    }
}
