using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	public bool moveRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
    public Rigidbody2D rb; //the object's RigidBody2D
    public GameObject groundCheck; //the object's groundCheck object
    private string state = "walking"; //The current state of the enemy
    public BoxCollider2D groundCollider;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //groundCollider = groundCheck.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        //enemy moves until the groundCheck is no longer touching the ground layer (layer 8)
        if (state == "walking")
            if (!groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
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
