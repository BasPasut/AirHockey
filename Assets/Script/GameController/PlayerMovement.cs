using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	bool isClicked;
	bool canMove;
	public Rigidbody2D rb;
    private Vector2 startPosition;

	public Transform BoundaryHolder;

	Boundary playerBoundary;

	Collider2D playerCollider;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        startPosition = rb.position;
		playerCollider = GetComponent<Collider2D>();

		playerBoundary = new Boundary (BoundaryHolder.GetChild (0).position.y, 
                                       BoundaryHolder.GetChild (1).position.y, 
                                       BoundaryHolder.GetChild (2).position.x, 
                                       BoundaryHolder.GetChild (3).position.x);
	}
	
	// Update is called once per frame
	void Update () {
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
