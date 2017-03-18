using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    public int coinScoreAmount;
    public static int Score { get; private set; }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pick Up")
        {
            Score += coinScoreAmount;
            print(Score);
            Destroy(collider.gameObject);
        }
    }
}
