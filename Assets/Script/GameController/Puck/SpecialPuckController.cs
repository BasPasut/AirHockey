using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPuckController : MonoBehaviour
{

    public float MaxSpeed;
    public CountDownTimer cdt;
    public GameObject SPPuck;
    public GameObject P1;
    public GameObject P2;

    private bool IsGoal;
    public AudioController audioController;


    // Use this for initialization
    void Start()
    {
        SPPuck.AddComponent<Rigidbody2D>();
        IsGoal = false;        
        StartCoroutine(SpawnSPPuck());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P2Goal")
        {
            IsGoal = true;
            if (SPPuck.gameObject.name == "PuckB")
            {
                audioController.playBuffSound();
                SPPuck.gameObject.SetActive(false);
                P2.transform.localScale *= 2;
            }
            else if (SPPuck.gameObject.name == "PuckF")
            {
                audioController.playDebuffSound();
                SPPuck.gameObject.SetActive(false);
                P2.transform.localScale /= 2;
            }
        }
        else if (other.tag == "P1Goal")
        {
            IsGoal = true;
            if (SPPuck.gameObject.name == "PuckB")
            {
                audioController.playBuffSound();
                SPPuck.gameObject.SetActive(false);
                P1.transform.localScale *= 2;
            }
            else if (SPPuck.gameObject.name == "PuckF")
            {
                audioController.playDebuffSound();
                SPPuck.gameObject.SetActive(false);
                P1.transform.localScale /= 2;
            }
        }
    }

    private IEnumerator SpawnSPPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        SPPuck.SetActive(true);
        //SPPuck. = new Vector2(0, 0);
        //SPPuck.position = new Vector2(Random.Range(-2.08f, 2.18f), 0);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.playCollisionSound();
    }


    private void FixedUpdate()
    {
       // SPPuck.velocity = Vector2.ClampMagnitude(SPPuck.velocity, MaxSpeed);
    }
}
