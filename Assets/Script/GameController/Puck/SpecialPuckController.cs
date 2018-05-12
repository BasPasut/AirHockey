using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Abstract for create SpecialPuckController
 */
public abstract class SpecialPuckController : MonoBehaviour
{
    /** Max speed of specialpuck */
    public float MaxSpeed;
    /** Rigidbody2D of specialpuck */
    public Rigidbody2D rb;
    /** GameObject of SPPuck */ 
    public GameObject SPPuck;
    /** GameObject of player 1 */
    public GameObject P1;
    /** GameObject of player 2 */
    public GameObject P2;
    /** boolean for check is specialpuck appear or not */
    public static bool IsAppear;

    public AudioController audioController;


    // Use this for initialization
    void Start()
    {
        rb = SPPuck.GetComponent<Rigidbody2D>();
        IsAppear = true;
    }

    /**
     * perform  specialpuck after it is in goal
     */
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

    /**
     * Reset specialpuck 
     */
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

    /** perform action of specialpuck */
    public abstract void BuffAction(GameObject player);
    /** spawn special puck  */
    public abstract void SpawnSPPuck(int currentTime);
}
