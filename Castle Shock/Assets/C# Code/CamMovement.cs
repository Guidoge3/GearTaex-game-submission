using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private struct PointInSpace
    {
        public Vector3 Position;
        public float Time;
    }

    public Transform target;
    private Vector3 offset;
    private float delay = 0.1f;
    private float speed = 5;
    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();

    void LateUpdate()
    {

        pointsInSpace.Enqueue(new PointInSpace() { Position = target.position, Time = Time.time });


        while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
        {
            transform.position = Vector3.Lerp(transform.position.Normalize, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
        }
    }
}
