using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public float speed;
    public float speedVariation = 2;
    public Direction direction;

    private Vector3 movement;
    
	void Start ()
    {
        float addedSpeed = Random.Range(-speedVariation, speedVariation);

        switch (direction)
        {
            case Direction.down:
                movement = new Vector3(0, -speed + addedSpeed, 0);
                break;
            case Direction.left:
                movement = new Vector3(-speed + addedSpeed, 0, 0);
                break;
            default:
                break;
        }
    }
	
	void Update ()
    {
        transform.position = transform.position + movement * Time.deltaTime;
	}

    public enum Direction
    {
        down,
        left
    }
}
