using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidBody;
    private Collider col;
    public int speed;
    public int pickupPointValue = 5;
    public GameManager gameManager;

   

    private void Start()
    {
        if(gameManager == null) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update () {
       
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

            gameManager.AddPoints(pickupPointValue);
            Destroy(collision.gameObject);
        }
        else
        {
            return;
        }
    }
}
