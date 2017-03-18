using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerPickUpController : MonoBehaviour
{
    public int coinScoreAmount;
    public int distanceScoreMultiplyAmount;
    public Text scoreDisplayText;

    private int pickUpScore = 0;
    private int DistanceScore = 0;
    private Vector3 startingPosition;
    private AudioSource audioSource;
    
    public static int Score { get; private set; }

    void Start()
    {
        startingPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!DeathController.IsDead)
            UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pick Up")
        {
            pickUpScore += coinScoreAmount;
            Destroy(collider.gameObject);
            audioSource.Play();
        }
    }

    private void UpdateScore()
    {
        Score = pickUpScore + CalculateDistanceScore();
        scoreDisplayText.text = string.Format("Score: {0}", Score);
    }

    private int CalculateDistanceScore()
    {
        return (int)((transform.position.x - startingPosition.x) * distanceScoreMultiplyAmount);
    }
}
