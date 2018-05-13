using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for Puck
 */
public class NormalPuckController : MonoBehaviour {

    /** ScoreController of Puck */
    public ScoreController ScoreControllerInstance;
    /** boolean for check if puck is in goal or not */
    public static bool IsGoal{get; private set;}
    /** max spped of Puck */
    public float MaxSpeed;
    /** Rigidbody2D of Puck */
    private Rigidbody2D rb;

    public AudioController audioController;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        IsGoal = false;
	}

    /**
     * Check if puck is in goal
     * 
     * @param other
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsGoal)
        {
            if(other.tag == "P2Goal")
            {
                ScoreControllerInstance.Increment(ScoreController.Score.P1Score);
                IsGoal = true;
                audioController.playGoalSound();
                StartCoroutine(ResetPuck(false));
            }
            else if(other.tag == "P1Goal")
            {
                ScoreControllerInstance.Increment(ScoreController.Score.P2Score);
                IsGoal = true;
                audioController.playGoalSound();
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.playCollisionSound();
    }

    /**
     * Reset puck after in goal 
     */
    private IEnumerator ResetPuck(bool IsP2Score)
    {
            yield return new WaitForSecondsRealtime(1);
            IsGoal = false;
            rb.velocity = rb.position = new Vector2(0, 0);
        if (IsP2Score)
        {
            rb.position = new Vector2(0, -1);
        }
        else
        {
            rb.position = new Vector2(0, 1);
        }
    }

    /**
     * Restart Puck position
     */
    public void RestartPuckPosition()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
