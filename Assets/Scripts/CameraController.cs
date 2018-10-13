using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        //if field reference not set by dev
        if(followTarget == null)
        {
            followTarget = GameObject.FindGameObjectWithTag("Player");//default to player
        }
        offset = transform.position - followTarget.transform.position;
		
	}

    //guaranteed to run after Update, before physics
	void LateUpdate () {
        transform.position = followTarget.transform.position + offset;
		
	}
}
