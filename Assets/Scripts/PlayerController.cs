using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidBody;
    private Collider col;
    public Text scoreText;
    public int speed;

    public int totalScore = 0;
    public int pointValue = 5;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update () {
        scoreText.text = "Score: " + totalScore.ToString();
		
	}

    //called before physics step
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rigidBody.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            totalScore += pointValue;
            Destroy(collision.gameObject);
        }
        else
        {
            return;
        }
    }
}
