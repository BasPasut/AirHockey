using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPuckController : MonoBehaviour
{

    public float MaxSpeed;
    public Rigidbody2D rb;
    public GameObject SPPuck;
    public GameObject P1;
    public GameObject P2;
    private bool IsGoal;

    public AudioController audioController;


    // Use this for initialization
    void Start()
    {
        rb = SPPuck.GetComponent<Rigidbody2D>();
        IsGoal = false;        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2Goal")
        {
            IsGoal = true;
            if (SPPuck.gameObject.name == "PuckB")
            {
                audioController.playBuffSound();
                ResetPuck();
                if (P2.transform.localScale.x == 1)
                {
                    P2.transform.localScale *= 2;
                }
            }
            else if (SPPuck.gameObject.name == "PuckF")
            {
                audioController.playDebuffSound();
                ResetPuck();
                if (P2.transform.localScale.x == 1)
                {
                    P2.transform.localScale /= 2;
                }
            }
        }
        else if (other.tag == "P1Goal")
        {
            IsGoal = true;
            if (SPPuck.gameObject.name == "PuckB")
            {
                audioController.playBuffSound();
                ResetPuck();
                if (P1.transform.localScale.x == 1)
                {
                    P1.transform.localScale *= 2;
                }
            }
            else if (SPPuck.gameObject.name == "PuckF")
            {
                audioController.playDebuffSound();
                ResetPuck();
                if (P1.transform.localScale.x == 1)
                {
                    P1.transform.localScale /= 2;
                }
            }
        }
    }

    public void SpawnSPPuck(float timeRemaining)
    {
        if ((int)timeRemaining % 20 == 0)
        {
            if (SPPuck.active == false)
            {
                SPPuck.SetActive(true);
                //rb.velocity = new Vector2(0, 0);
                rb.position = new Vector2(Random.Range(-2.08f,2.16f), 0);
            }
        }

    }

    public void ResetPuck()
    {
        rb.position = new Vector2(0, 0);
        SPPuck.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.playCollisionSound();
    }


    private void FixedUpdate()
    {
       rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
