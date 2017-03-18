using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public float yThreshHold;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

	void Update ()
    {
        if (transform.position.y < -yThreshHold)
        {
            ActiveDeathSquence();
        }
	}

    private void ActiveDeathSquence()
    {
        print("You died");
        transform.position = startingPosition;
    }
}
