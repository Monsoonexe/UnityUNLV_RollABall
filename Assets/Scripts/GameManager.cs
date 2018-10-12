﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int scoreCount = 0;
    public GameObject[] pickUpList;
    public PlayerController playerController;

    public Text scoreText;
    public Text winText;
    public string winString = "Congradulations!";
    public string loseString = "You lost! Try again!";

    // Use this for initialization
    void Start () {
        if(playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        pickUpList = GameObject.FindGameObjectsWithTag("Pickup");
        winText.text = "";
        playerController.acceptPlayerInput = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScoreText();

        if (CheckWinCondition())
        {
            winText.text = winString;
            playerController.acceptPlayerInput = false;
            StartCoroutine(LoadNextLevel());
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
        //Debug.Log("The scene should be reloading now....");//print test
        //TODO tell GM how death occured or fail event
        winText.text = loseString;
        playerController.acceptPlayerInput = false;
        StartCoroutine(LoadNextLevel());
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    private IEnumerator LoadNextLevel()
    {
        Debug.Log("The scene should be reloading now....");//print test
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reload this scene
    }

    
}
