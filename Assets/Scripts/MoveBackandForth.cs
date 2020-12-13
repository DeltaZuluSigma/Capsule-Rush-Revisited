using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackandForth : MonoBehaviour
{
    public int direction = 1;
    public Vector3 Movement;
    public float speed = 3f;

    private Vector3 OriginPoint;
    private Vector3 DestinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        OriginPoint = this.transform.position;
        DestinationPoint = OriginPoint + Movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            if(transform.position != OriginPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, OriginPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 0;
                transform.position = Vector3.MoveTowards(transform.position, DestinationPoint, speed * Time.deltaTime);
            }
        }
        else if (direction == 0)
        {
            if(transform.position != DestinationPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, DestinationPoint, speed * Time.deltaTime);
            }
            else
            {
                direction = 1;
                transform.position = Vector3.MoveTowards(transform.position, OriginPoint, speed * Time.deltaTime);
            }
        }
    }
}
