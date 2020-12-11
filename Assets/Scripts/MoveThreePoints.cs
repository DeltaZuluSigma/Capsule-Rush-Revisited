using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThreePoints : MonoBehaviour
{
    private int direction = 1;
    public Vector3 firstPoint;
    public Vector3 secondPoint;
    public Vector3 thirdPoint;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            if(transform.position != firstPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, firstPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 2;
                transform.position = Vector3.MoveTowards(transform.position, secondPoint, speed * Time.deltaTime);
            }
        }
        else if (direction == 2)
        {
            if(transform.position != secondPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, secondPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 3;
                transform.position = Vector3.MoveTowards(transform.position, thirdPoint, speed * Time.deltaTime);
            }
        }
        else if (direction == 3)
        {
            if(transform.position != thirdPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, thirdPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 1;
                transform.position = Vector3.MoveTowards(transform.position, firstPoint, speed * Time.deltaTime);
            }
        }
    }
}
