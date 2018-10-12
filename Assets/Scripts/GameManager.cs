using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int scoreCount = 0;
    public GameObject[] pickUpList;
    public PlayerController playerController;

    public Text scoreText;
    public Text winText;
    public string winString = "Congradulations!";

    // Use this for initialization
    void Start () {
        if(playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        pickUpList = GameObject.FindGameObjectsWithTag("Pickup");
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScoreText();

        if (CheckWinCondition())
        {
            winText.text = winString;
            //TODO 
            //stop taking player controller input
            //
        }
        
    }

    private bool CheckWinCondition()
    {

        //TODO different win condition bool
        //if win by scoring
        if (scoreCount == pickUpList.Length * playerController.pickupPointValue) // check for win condition
        {
            return true;
        }
        return false;
    }

    public void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
        UpdateScoreText();
    }

    public void OnPlayerDeath()
    {
        //TODO tell GM how death occured or fail event

    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }
}
