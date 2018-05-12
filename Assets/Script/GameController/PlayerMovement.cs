using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for player to perform a movement when we click and drag
 */
public class PlayerMovement : MonoBehaviour {
	/** boolean for check if player have been clicked or not */
	 private bool isClicked;
    /** boolean for check if player can move */
	 private bool canMove;
    /** Rigidbody2D for player */
	public Rigidbody2D rb;
    /** Start position for player */
    private Vector2 startPosition;
    /** Transfrom of Boundary */
	public Transform BoundaryHolder;

    /** Boundary of playerBoundary */
	private Boundary playerBoundary;
    /** Collider2D of player  */
	private Collider2D playerCollider;

	// Use this for initialization
	private void Start () {
		rb = GetComponent<Rigidbody2D> ();
        startPosition = rb.position;
		playerCollider = GetComponent<Collider2D>();

		playerBoundary = new Boundary (BoundaryHolder.GetChild (0).position.y, 
                                       BoundaryHolder.GetChild (1).position.y, 
                                       BoundaryHolder.GetChild (2).position.x, 
                                       BoundaryHolder.GetChild (3).position.x);
	}
	
    /**
     * check if we click on the player or not if we click the player will follow our cursor 
     */
	// Update is called once per frame
	private void Update () {
		if (Input.GetMouseButton (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (isClicked) {
				isClicked = false;
				//check whether the cursor is on the player or not
				if (playerCollider.OverlapPoint(mousePosition)) {
					canMove = true;
				} else {
					canMove = false;
				}
			}
			if (canMove) {
				Vector2 clampedMousePosition = new Vector2 (Mathf.Clamp(mousePosition.x,playerBoundary.Left,playerBoundary.Right),
					                                        Mathf.Clamp(mousePosition.y,playerBoundary.Down,playerBoundary.Up));
				rb.MovePosition(clampedMousePosition);
			}
		} else {
			isClicked = true;
		}
	}

    /**
     * Reset player
     */
    public void ResetPositon()
    {
        rb.position = startPosition;
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
