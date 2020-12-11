using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private float distance = 4.0f;  // Amount to move left and right from the start point. x amount on each side
    private float speed = 2.0f;//speed that platform moves
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 temp = startPos;
        temp.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = temp;
    }
}
