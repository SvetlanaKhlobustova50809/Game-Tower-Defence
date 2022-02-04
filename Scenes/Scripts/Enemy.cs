using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed, RotationSpeed;
    public Transform[] Points;

    private Transform currentPoint;
    private int index;
    private Vector3 direction;

    void Start()
    {
        index = 0;
        currentPoint = Points[index];
    }
    void Update()
    {
        direction = transform.position - currentPoint.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * RotationSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime*Speed);

        if (transform.position == currentPoint.position)
        {
            index++;

            if (index >= Points.Length)
            {
                Destroy(gameObject);
            }
            else
                currentPoint = Points[index];
        }
    }
}
