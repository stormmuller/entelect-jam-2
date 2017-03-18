using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    public static float yThreshHold = -5;
    public GameObject fader;
    public Text scoreTextOnFader;

    private Vector3 startingPosition;
    public static bool IsDead { get; private set; }

    void Start()
    {
        startingPosition = transform.position;
        IsDead = false;
    }

	void Update ()
    {
        if (transform.position.y < yThreshHold)
        {
            ActiveDeathSquence();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            ActiveDeathSquence();
        }
    }

    private void ActiveDeathSquence()
    {
        IsDead = true;
        scoreTextOnFader.text = "Score: " + PlayerPickUpController.Score.ToString();
        fader.SetActive(true);
    }
}
