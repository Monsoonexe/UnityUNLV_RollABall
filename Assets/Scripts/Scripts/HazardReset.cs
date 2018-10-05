using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardReset : MonoBehaviour {

	public PlayerController p1;
	public SecondController p2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveP = (Mathf.Sin(Time.time) * .1f);
		transform.Translate(moveP, 0, 0);
		
	}
	
	private void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Vector3 p1Start = p1.startposition;
			Vector3 p2Start = p2.startposition;
			p1.transform.position = p1Start;
			p2.transform.position = p2Start;
		}
	}
}