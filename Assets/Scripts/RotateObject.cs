using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
    public string direction;

    // Use this for initialization
    void Start()
    {
        if (direction.ToLower().Equals("r") || direction.ToLower().Equals("right"))
            StartCoroutine(DoRotateObject(90, Vector3.right, rotationSpeed));
        else
            StartCoroutine(DoRotateObject(90, Vector3.left, rotationSpeed));
    }

    IEnumerator DoRotateObject(float angle, Vector3 axis, float inTime)
    {
        // calculate rotation speed
        float rotationSpeed = angle / inTime;

        while (true)
        {
            // save starting rotation position
            Quaternion startRotation = transform.rotation;

            float deltaAngle = 0;

            // rotate until reaching angle
            while (deltaAngle < angle)
            {
                deltaAngle += rotationSpeed * Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, angle);

                transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);

                yield return null;
            }

            if (axis == Vector3.left)
                axis = Vector3.right;
            else
                axis = Vector3.left;

            // delay here
            yield return new WaitForSeconds(1);
        }
    }
}
