using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    public int direction = 1;
    public Vector3 posPoint;
    public Vector3 negPoint;

    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            if(transform.position != posPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, posPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 0;
                transform.position = Vector3.MoveTowards(transform.position, negPoint, speed * Time.deltaTime);
            }
        }
        else if (direction == 0)
        {
            if(transform.position != negPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, negPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 1;
                transform.position = Vector3.MoveTowards(transform.position, posPoint, speed * Time.deltaTime);
            }
        }
    }
}
