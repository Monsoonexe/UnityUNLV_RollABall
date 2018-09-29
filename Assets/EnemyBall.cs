using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour {
    private Collider col;
    public int bumpForce = 1;

	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //Vector3 bumpVector = new Vector3(collision.);
            playerRigidbody.AddForce( transform.position * bumpForce);
        }
        else
        {
            return;
        }
    }
}
