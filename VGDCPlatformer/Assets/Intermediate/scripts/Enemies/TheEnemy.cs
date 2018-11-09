using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	public bool moveRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
    public Rigidbody2D rb; //the object's RigidBody2D
    private string state = "walking"; //The current state of the enemy
    private BoxCollider2D groundCheck; //the object's groundCheck collider

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = gameObject.GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        //enemy moves until the groundCheck is no longer touching the ground layer (layer 8)
        if (!groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
		{
		    Flip();
		}
	}

    void FixedUpdate()
    {
        if (moveRight == true)
        {
            rb.velocity = Vector2.right * movSpeed;
        }
        else
        {
            rb.velocity = Vector2.left * movSpeed;
        }
        
    }

    //Destroys the GameObject
    public void Die()
	{
		Destroy(gameObject);
	}

    //flips the entire gameObject and its components
    void Flip()
    {
        moveRight = !moveRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
