using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ghostMovement : MonoBehaviour
{
    int cur = 0;
    public Vector2 startingDirection;
    private Vector2 currentDirection = Vector2.up;
    public float speed = 0.3f;
    private bool ghostActive = true;
    private Vector2 startingPosition;
    Vector2 dest = Vector2.zero;
    void Start()
    {
        startingPosition = (Vector2)transform.position;
        currentDirection = startingDirection;
        dest = (Vector2)transform.position + (currentDirection);
    }
    void FixedUpdate()
    {
        if (ghostActive)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
            dest = (Vector2)transform.position + (currentDirection);
        }
    }
    public void stopGhost()
    {
        ghostActive = false;
    }
    public void resetGhost()
    {
        dest = startingPosition;
    }
    public void changeDirection(List<Vector2> validDirections)
    {
        if (validDirections.Count > 0)
        {
            System.Random rand = new System.Random();
            int newDirection = rand.Next(0, validDirections.Count);
            // So if changing direction would make the ghost do a 180, try again.
            if (validDirections[newDirection] == (-1 * currentDirection))
            {
                validDirections.RemoveAt(newDirection);
                changeDirection(validDirections);
            }
            else
            {
                //TODO: Add some logic to figure out where pacman is in the maze, and give the best direction to catch him a higher weight
                currentDirection = validDirections[newDirection];
                dest = (Vector2)transform.position + validDirections[newDirection];
            }
        }
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.CompareTag("decisionPoint"))
        {
            GameObject decisionPoint = co.transform.gameObject;
            DecisionCollider decisionInfo = decisionPoint.GetComponent<DecisionCollider>();
            List<Vector2> validDirections = new List<Vector2>();
            if (decisionInfo.upValid)
                validDirections.Add(Vector2.up);
            if (decisionInfo.downValid)
                validDirections.Add(Vector2.down);
            if (decisionInfo.leftValid)
                validDirections.Add(Vector2.left);
            if (decisionInfo.rightValid)
                validDirections.Add(Vector2.right);
            changeDirection(validDirections);
        }
    }
   

}