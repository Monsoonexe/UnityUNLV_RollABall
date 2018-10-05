using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PickUpMoveHorizontal : MonoBehaviour {

    public float speed = 2;
    public bool moveOnX = true;
    public bool moveOnZ = false;
    //Distance from one end to the other
    public float distance = 8;
    bool leftVisited = false;
    bool rightVisited = false;
    //Start position
    Vector3 startpos;

	// Use this for initialization
	void Start () {
        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        //If toggled to move on x
        if(moveOnX && !moveOnZ)
        {
            //Go all the way left, then mark that you're there
            if ((Math.Abs(transform.position.x - startpos.x) < distance) && !leftVisited)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                leftVisited = true;
                rightVisited = false;
            }
            //Then go all the way right, then do it all over again!
            if (transform.position.x <= startpos.x && leftVisited && !rightVisited)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                rightVisited = true;
                leftVisited = false;
            }
        }

        //If toggled to move on z
        else if(moveOnZ && !moveOnX)
        {
            //Go all the way up, then mark that you're there
            if ((Math.Abs(transform.position.z - startpos.z) < distance) && !leftVisited)
            {
                transform.position += Vector3.forward* speed * Time.deltaTime;
            }
            else
            {
                leftVisited = true;
                rightVisited = false;
            }
            //Then go all the way down, then do it all over again!
            if (transform.position.z >= startpos.z && leftVisited && !rightVisited)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            else
            {
                rightVisited = true;
                leftVisited = false;
            }
        }

        //If toggled to do both, move diagonally
        else if(moveOnX && moveOnZ)
        {
            //Go all the way left, then mark that you're there
            if ((Math.Abs(transform.position.x - startpos.x) < distance) && (Math.Abs(transform.position.z - startpos.z) < distance) && !leftVisited)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else
            {
                leftVisited = true;
                rightVisited = false;
            }
            //Then go all the way right, then do it all over again!
            if (transform.position.x <= startpos.x && transform.position.z >= startpos.z && leftVisited && !rightVisited)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            else
            {
                rightVisited = true;
                leftVisited = false;
            }
        }
       
	}
}
