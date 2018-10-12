using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBehavior : MonoBehaviour {
    private float count;
    public float height;
    public float speed;
    public bool sideToSide;
    private bool direction = true;
    //private float piAdd;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {

        if (direction == true)
        {
            count += .01f * speed;
        }else if (direction == false)
        {
            count -= .01f * speed;
        }

        if (count >= height)
        {
            count = 0;
            direction = false;
        }
        else if (count <= -(height))
        {
            count = 0;
            direction = true;
        }
        if (sideToSide == true)
        {
            transform.Translate(count * Time.deltaTime, 0f, 0f);
        }
        else if (sideToSide == false)
        {
            transform.Translate(0f, count*Time.deltaTime, 0f);
        }
        
        
	}
}
