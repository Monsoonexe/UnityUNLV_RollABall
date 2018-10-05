using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController_WithScoreUpdate : MonoBehaviour {

    private Rigidbody rb;
    private int scoreCount;
    public float speed;
    public float jumpHeight;
    public float pubBoost;
    private float dash;
    private bool canJump;
    private bool canDash;

    public Text countText;
    public Text WinText;
    
	// Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreCount = 0;
        SetCountText();
        WinText.text = "";
        canJump = true;
        canDash = true;
    }
    // Update is called once per frame
    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Jump
        float jump;
        if (Input.GetKeyDown(KeyCode.Space) & canJump == true){
            jump = jumpHeight;
            canJump = false;
        }
        else
        {
            jump = 0f;
        }
        //end jump
        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift) & canDash == true)
        {
            StartCoroutine(wait());
            dash = pubBoost;
            canDash = false;
        }
        else
        {
            dash = 1;
        }
        //end dash
        Vector3 movement = new Vector3(horizontal*dash, jump, vertical*dash);
        rb.AddForce(movement * speed);

        
	}
    void OnTriggerEnter(Collider hitObject)
    {
        //checking for map hits to reset jump
        if (hitObject.gameObject.CompareTag("Map"))
        {
            canJump = true;
        }
        if (hitObject.gameObject.CompareTag("Pick Up"))
        {
            hitObject.gameObject.SetActive(false);
            scoreCount = scoreCount + 1;
            SetCountText();
        }
        if (hitObject.gameObject.CompareTag("Death Zone"))
        {
            gameObject.SetActive(false);
            scoreCount = 9;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + scoreCount.ToString();

        if (scoreCount == 8)
        {
            WinText.text = "Congradulations! You Win!";
        }else if (scoreCount == 9)
        {
            WinText.text = "Game Over!";
        }

    }
    //Dash delay
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        canDash = true;
    }
}
