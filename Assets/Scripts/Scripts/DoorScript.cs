using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	private PlayerController player;
	private SecondController player2;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
		player2 = GameObject.FindObjectOfType<SecondController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if((player.totalScore >=15 || player2.totalScore >= 15) && counter < 10)
		{
			
			transform.Translate((Time.deltaTime * 0.7f), 0, 0);
			
		}
		
	}
}
