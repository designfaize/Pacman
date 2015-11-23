using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ghostMovement : MonoBehaviour
{
    int cur = 0;

    public float speed = 0.3f;
    private string _lastAxis;
    private Vector2 _lastDirection;
    private Vector2 _lastXDirection;
    private Vector2 _lastYDirection;
    private bool invalid = false;
    Vector2 dest = Vector2.zero;
     void Start()
    {
        _lastAxis= "vertical";
        _lastYDirection = Vector2.up;
        _lastXDirection = Vector2.left;
        _lastDirection = _lastYDirection;
        dest = (Vector2)transform.position + (_lastDirection);
    }
    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        dest = (Vector2)transform.position + (_lastDirection);

    }

    private void changeDirection()
    {
        
        System.Random positiveOrNegative = new System.Random();
        int rand = positiveOrNegative.Next(0, 1) * 2 - 1;
        Debug.Log("Last Direction " + _lastAxis);
        if (_lastAxis == "vertical")
        {
             _lastXDirection = rand * _lastXDirection;
            _lastAxis = "horizontal";
            _lastDirection =  _lastXDirection;
            dest = (Vector2)transform.position + (_lastDirection);
        }
        else
        {
             _lastYDirection = rand * _lastYDirection;
            _lastAxis = "vertical";
            _lastDirection = _lastYDirection;
            dest = (Vector2)transform.position + ( _lastDirection);
        }
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.CompareTag("level"))
        {
            Debug.Log("Hit the level");
            dest = (Vector2)transform.position + (Vector2.zero);
            changeDirection();
        }
    }
}