using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBehavior : MonoBehaviour {
    public GameManager gameManager;
    public PlayerController playerController;
    public int requiredScoreToDestroy;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        requiredScoreToDestroy = (gameManager.pickUpList.Length - 1) * playerController.pickupPointValue;
        

    }
    void Update()
    {
        if (gameManager.scoreCount >= requiredScoreToDestroy)
        {
            gameObject.SetActive(false);
        }
        
    }
}
