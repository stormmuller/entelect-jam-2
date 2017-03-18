using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotateSpeed;
    	
	void Update ()
    {
        RotateCoinBySpeed();
	}

    private void RotateCoinBySpeed()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }
}
