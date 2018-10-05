using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallScript : MonoBehaviour {

	private Collider col; 
	public int bumpForce = 1;
	private Rigidbody playerRigidBody;

	// Use this for initialization
	void Start () {
		col = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		
		if(collision.gameObject.CompareTag("Player"))
		{
			Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
			playerRigidBody = collision.gameObject.GetComponent<Rigidbody>();
			playerRigidBody.AddForce(movement);
			
		}
		
		else 
		{
			return;
		}
	}
	
}
