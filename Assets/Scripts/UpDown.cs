
using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour
{
    private float speed = 1.0f;
    private float height = 10;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    void FixedUpdate()
    {
        
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;//calculates new y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}