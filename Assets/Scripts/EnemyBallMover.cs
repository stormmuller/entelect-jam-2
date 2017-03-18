using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallMover : MonoBehaviour {

    public float speed;

    private Rigidbody2D ballRb;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }
    
	void FixedUpdate ()
    {
        ballRb.velocity = new Vector2(-speed, ballRb.velocity.y);
	}
}
