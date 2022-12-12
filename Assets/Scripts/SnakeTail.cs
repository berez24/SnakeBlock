using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    
    public float CircleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();


    //public Vector3 _previosMousePosition;
    //public float Speed;
    //public float Distance;
    //private Transform _transform;
    //public float Sensitivity;
    //public List<Transform> Tails;

    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    private void Update()
    {

////        MoveSnake(_transform.position + _transform.forward * Speed);
//        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

//        if (Input.GetMouseButton(0))
//        {
//            Vector3 delta = Input.mousePosition - _previosMousePosition;
//            SnakeHead.Rotate(delta.y * Sensitivity, 0, 0);
//        }

//        _previosMousePosition = Input.mousePosition;




        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
    }


}