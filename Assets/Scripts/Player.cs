using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;
    public Game Game;
    public Transform SnakeHead;

    public int value;
    public int Health = 1;
    private Rigidbody componentRigidbody;
    Vector3 tempVect = new Vector3(0, 0, 1);
    private Vector3 _previousMousePosition;
    public TextMeshPro PointsText;
    public int Length = 1;
    private SnakeTail componentSnakeTail;

    //public float bounce;


    public float Sensitivity;

    public Vector3 _previosMousePosition;
    //public List<Transform> Tails;
    //public float Distance;



    //private List<Transform> snakeCircles = new List<Transform>();
    //private List<Vector3> positions = new List<Vector3>();

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        componentRigidbody = GetComponent<Rigidbody>();
        PointsText.SetText(Health.ToString());
        componentSnakeTail = GetComponent<SnakeTail>();
    }

    void Update()
    {
        //Движение с помощью клавиш
        //MoveSnake(_transform.position + _transform.forward * Speed);

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        //float angel = Input.GetAxis("Horizontal") * Sensitivity;
        //SnakeHead.Rotate(0, angel, 0);


        //MoveSnake(_transform.position + _transform.forward * Speed);
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            SnakeHead.transform.position = new Vector3(SnakeHead.transform.position.x + Input.GetAxis("Mouse X"), 0, SnakeHead.transform.position.z);
            //Vector3 delta = Input.mousePosition - _previosMousePosition;
            //SnakeHead.Rotate(delta.x * Sensitivity, 0,  0);
            //Vector3 newPosition = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + tempVect.z);
            //componentRigidbody.MovePosition(newPosition);
        }

        _previosMousePosition = Input.mousePosition;


    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            value = collision.gameObject.GetComponent<Food>().Value;
            Health += value;
            PointsText.SetText(Health.ToString());
            Destroy(collision.gameObject);

            for (int i = 0; i < value; i++)
            {
                Length++;
                //MoveSnake(_transform.position + _transform.forward * Speed);
                componentSnakeTail.AddCircle();
            }
        }
        else if (collision.gameObject.tag == "Block")
        {


            //value = collision.gameObject.GetComponent<Block>().Value;
            ////for (int i = 0; i <= value; i++)
            ////{
            //    value--;
            //    componentRigidbody.velocity = new Vector3(0, 0, -bounce);

            //for (int i = 0; i < value; i++)
            //{
            //    Length--;
            //    componentSnakeTail.RemoveCircle();
            //}

            //Debug.Log(value);

            //}




            value = collision.gameObject.GetComponent<Block>().Value;
            //componentRigidbody.velocity = new Vector3(0, 0, -bounce);
            if (value >= Health)
            //if (Health < 1)
            {
                Game.OnPlayerDied();
                componentRigidbody.velocity = Vector3.zero;
            }
            else
            {
                //Health--;
                //componentSnakeTail.RemoveCircle();
                //value--;
                Health -= value;
                PointsText.SetText(Health.ToString());
                //PointsText.SetText(value.ToString());
                Destroy(collision.gameObject);

                //if(value < 1) Destroy(collision.gameObject);

                //Debug.Log(Health);
                    for (int i = 0; i < value; i++)
                    {
                        Length--;
                        componentSnakeTail.RemoveCircle();
                    }
                }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Game.OnPlayerWon();
            componentRigidbody.velocity = Vector3.zero;
        }
    }

    //private void MoveSnake(Vector3 newPosition)
    //{
    //    float sqrDistance = Distance * Distance;
    //    Vector3 previosPosition = _transform.position;

    //    foreach (var bone in Tails)
    //    {
    //        if ((bone.position - previosPosition).sqrMagnitude > sqrDistance)
    //        {
    //            var temp = bone.position;
    //            bone.position = previosPosition;
    //            previosPosition = temp;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    _transform.position = newPosition;
    //}
    //private IEnumerator DelayedAction()
    //{
    //    yield return new WaitForSeconds(60);
    //}
}
