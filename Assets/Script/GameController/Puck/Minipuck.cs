using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minipuck : NormalPuckController
{

    private Rigidbody2D minipuck;
    void Start()
    {
        minipuck = GetComponent<Rigidbody2D>();
        minipuck.transform.localScale /= 2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2Goal")
        {
            ScoreControllerInstance.Increment(ScoreController.Score.P1Score);
            audioController.playGoalSound();
        }
        else if (other.tag == "P1Goal")
        {
            ScoreControllerInstance.Increment(ScoreController.Score.P2Score);
            audioController.playGoalSound();
        }
    }
}
