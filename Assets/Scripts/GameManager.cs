using System.Collections;
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
    public string winString = "Congratulations!";
    public string loseString = "You lost! Try again!";

    public int secondsDelayUntilNextLevelLoads = 3;

    public List<Key> keyList = new List<Key>(); // arbitrary starting number of 20 keys

    // Use this for initialization
    void Start () {
        //check for references in case developers did not set them by hand in scene
        if(playerController == null)
        {
            Debug.Log("PlayerController reference not set. Searching scene....");//
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        if(scoreText == null)
        {
            Debug.Log("ScoreText reference not set. Searching scene....");//
            scoreText = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Text>();
        }
        if(winText == null)
        {
            Debug.Log("WinText reference not set. Searching scene....");//
            winText = GameObject.FindGameObjectWithTag("WinText").GetComponent<Text>();
        }

        //get a list of all the collectiables in the scene to keep track of them
        pickUpList = GameObject.FindGameObjectsWithTag("Pickup");
        //this text should be blank until we hve something to say
        winText.text = "";
        //good to get player input now
        playerController.acceptPlayerInput = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScoreText();//match GUI element with internal data

        if (CheckWinCondition())//have we won yet?
        {
            PlayerVictory();//do the things that happen at victory time
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

    private void PlayerVictory()
    {
        //TODO
        //play victory music
        //go on to next level, not reload
        //option to quit and go back to main menu
        winText.text = winString;//show victory text to player
        playerController.acceptPlayerInput = false; // stop getting input from player
        StartCoroutine(LoadNextLevel());//load the next level (currently reloads single scene)
    }

    public void AddKey(Key newKey)
    {
        keyList.Add(newKey);

    }

    public void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
        UpdateScoreText();//Match GUI element to internal data
    }

    public void OnPlayerDeath()
    {
        //Debug.Log("The scene should be reloading now....");//print test
        //TODO tell GM how death occured or fail event
        winText.text = loseString;//show losing text to player
        playerController.acceptPlayerInput = false;//stop looking for input from player to control ball
        StartCoroutine(LoadNextLevel());//load next scene or reload this scene
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();
    }

    private IEnumerator LoadNextLevel()
    {
        Debug.Log("The scene should be reloading now....");//print test
        yield return new WaitForSeconds(secondsDelayUntilNextLevelLoads);//wait some time for the player to reflect on their actions
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reload this scene
    }

    
}
