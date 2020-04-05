using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform[] transformPoints;

    private bool forwardDir = true;
    private int currentPoint;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transformPoints[currentPoint].transform.position,
            speed * Time.deltaTime);
        CheckPoint();
    }

    private void CheckPoint()
    {
        if (Vector2.Distance(transform.position, transformPoints[currentPoint].transform.position) < 0.1f)
        {
            int nextPoint = forwardDir ? currentPoint + 1 : currentPoint - 1;

            if (forwardDir)
            {
                Forward(nextPoint);
            }
            else
            {
                Back(nextPoint);
            }
        }
    }

    private void Forward(int nextPoint)
    {
        if (nextPoint == transformPoints.Length)
        {
            forwardDir = false;
            currentPoint--;
        }
        else
        {
            currentPoint++;
        }
    }

    private void Back(int nextPoint)
    {
        if (nextPoint < 0)
        {
            forwardDir = true;
            currentPoint++;
        }
        else
        {
            currentPoint--;
        }
    }
}
