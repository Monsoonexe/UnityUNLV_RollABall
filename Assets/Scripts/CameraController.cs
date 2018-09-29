using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
		
	}

    //guaranteed to run after Update, before physics
	void FixedUpdate () {
        transform.position = player.transform.position + offset;
		
	}
}
