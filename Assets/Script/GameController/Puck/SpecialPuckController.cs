using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialPuckController : MonoBehaviour
{

    public float MaxSpeed;
    public Rigidbody2D rb;
    public GameObject SPPuck;
    public GameObject P1;
    public GameObject P2;
    public static bool IsAppear;

    public AudioController audioController;


    // Use this for initialization
    void Start()
    {
        rb = SPPuck.GetComponent<Rigidbody2D>();
        IsAppear = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2Goal")
        {
            BuffAction(this.P2);
        }
        else if (other.tag == "P1Goal")
        {
            BuffAction(this.P1);
        }
    }

    public void ResetPuck()
    {
        SPPuck.gameObject.SetActive(false);
        IsAppear = false;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.playCollisionSound();
    }


    private void FixedUpdate()
    {
       rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

    public abstract void BuffAction(GameObject player);

    public abstract void SpawnSPPuck(float timeRemaining);
}
