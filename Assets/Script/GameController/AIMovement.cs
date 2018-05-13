using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for AI to play the game
 */
public class AIMovement : MonoBehaviour
{
    /** max speed for AI */
    public float MaxMovementSpeed;
    /** Rigidbody2D for AI */
    public Rigidbody2D rb;
    /** Start position for the AI*/
    private Vector2 startingPosition;

    /** Rigidbody2D of Puck */
    public Rigidbody2D Puck;
    /** Rigidbody2D of DebuffPuck*/
    public Rigidbody2D Debuffpuck;
    /** Rigidbody2D of BuffPuck*/
    public Rigidbody2D buffpuck;

    /** Transform of PlayerBoundary */
    public Transform PlayerBoundaryHolder;
    /** Boundary playerBoundary*/
    private Boundary playerBoundary;

    /** Transform of PuckBoundaryr */
    public Transform PuckBoundaryHolder;
    /** Boundary of PuckBoundary*/
    private Boundary puckBoundary;

    public BuffPuck buff;
    public DebuffPuck debuff;

    /** targetPosition for AI */
    private Vector2 targetPosition;

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
                MaxMovementSpeed = 20;
                break;
            case AILevel.Level.impossible:
                MaxMovementSpeed = 30;
                break;
        }

    }

    private void FixedUpdate()
    {
        if (SpecialPuckController.IsAppear)
        {
            if (buff.apPear)
                SetAiMovePosition(buffpuck);

            else if(debuff.apPear)
                SetAiMovePosition(Debuffpuck);
        }
        else
        {
            if (!NormalPuckController.IsGoal)
            {
                SetAiMovePosition(Puck);
            }
        }
    }

    /**
     * Calculate normal puck to hit it back to main player when SpecialPuck is appear on scene.
     * It will hit the buff puck and debuff puck first.
     * 
     * @param PuckType puck type that appear on scene.
     */
    public void SetAiMovePosition(Rigidbody2D PuckType)
    {
        float movementSpeed;
        if (PuckType.position.y < puckBoundary.Down)
        {
            if (offSetDelay)
            {
                offSetDelay = false;
                XaxisDelay = Random.Range(-1f, 1f);
            }
            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
            targetPosition = new Vector2(Mathf.Clamp(PuckType.position.x + XaxisDelay, playerBoundary.Left, playerBoundary.Right), startingPosition.y);
        }
        else
        {
            offSetDelay = true;
            movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(PuckType.position.x, playerBoundary.Left, playerBoundary.Right),
                                          Mathf.Clamp(PuckType.position.y, playerBoundary.Down, playerBoundary.Up));
        }
        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
            movementSpeed * Time.fixedDeltaTime));
    }

    /**
     * Reset position of the puck when it is in the goal
     */
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
