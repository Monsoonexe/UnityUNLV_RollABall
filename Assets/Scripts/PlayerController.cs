using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameManager gameManager;
    public bool acceptPlayerInput = true;

    public int pickupPointValue = 5;
    public float speed = 5;
    public float jumpHeight = 15;
    public float pubBoost = 100;

    private Rigidbody rb;
    private float dash;
    public bool canJump;
    private bool canDash;
    
	// Use this for initialization
    void Start()
    {
        if (gameManager == null) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        canJump = true;
        canDash = true;
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Jump
        float jump;
        if (Input.GetKeyDown(KeyCode.Space) & canJump == true)
        {
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
            StartCoroutine(Wait());
            dash = pubBoost;
            canDash = false;
        }
        else
        {
            dash = 1;
        }
        //end dash
        Vector3 movement = new Vector3(horizontal * dash, jump, vertical * dash);
        rb.AddForce(movement * speed);

    }
    // Update is called once per frame
    void Update () {
        if (acceptPlayerInput)
        {
            HandleMovement();
        }
	}
    private void FixedUpdate()
    {
        
    }
    void OnTriggerEnter(Collider hitObject)
    {
        //checking for map hits to reset jump
        if (hitObject.gameObject.CompareTag("Map") || hitObject.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (hitObject.gameObject.CompareTag("Pickup"))
        {
            gameManager.AddPoints(pickupPointValue);
            hitObject.gameObject.SetActive(false);
        }
        if (hitObject.gameObject.CompareTag("Death Zone"))
        {
            //TODO
            gameManager.OnPlayerDeath();
            gameObject.SetActive(false);
        }
    }

    //Dash delay
    IEnumerator Wait(int waitTime = 3)
    {
        yield return new WaitForSeconds(waitTime);
        canDash = true;
    }
}
