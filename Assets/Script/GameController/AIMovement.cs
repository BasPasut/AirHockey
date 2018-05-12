using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{

    public float MaxMovementSpeed;
    public Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D Puck;
    public Rigidbody2D Buffpuck;
    public Rigidbody2D Debuffpuck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;
    private Vector2 targetPosition2;
    private bool offSetDelay = false;
    private float XaxisDelay;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                                        PlayerBoundaryHolder.GetChild(1).position.y,
                                        PlayerBoundaryHolder.GetChild(2).position.x,
                                        PlayerBoundaryHolder.GetChild(3).position.x);
        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                        PuckBoundaryHolder.GetChild(1).position.y,
                                        PuckBoundaryHolder.GetChild(2).position.x,
                                        PuckBoundaryHolder.GetChild(3).position.x);

        switch (AILevel.selector)
        {
            case AILevel.Level.normal:
                MaxMovementSpeed = 10;
                break;
            case AILevel.Level.hard:
                MaxMovementSpeed = 15;
                break;
            case AILevel.Level.impossible:
                MaxMovementSpeed = 20;
                break;
        }

    }

    private void FixedUpdate()
    {
        if (!NormalPuckController.IsGoal)
        {
            float movementSpeed;
            if (Puck.position.y < puckBoundary.Down)
            {
                if (offSetDelay)
                {
                    offSetDelay = false;
                    XaxisDelay = Random.Range(-5f, 5f);
                }
                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + XaxisDelay, playerBoundary.Left, playerBoundary.Right), startingPosition.y);
            }
            else
            {
                offSetDelay = true;
                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
                                              Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up));
            }
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                movementSpeed * Time.fixedDeltaTime));
        }
    }

    public void ResetPositon()
    {
        rb.position = startingPosition;
        if (rb.transform.localScale.x > 1)
        {
            rb.transform.localScale /= 2;
        }
        if (rb.transform.localScale.x < 1)
        {
            rb.transform.localScale *= 2;
        }
    }
}
