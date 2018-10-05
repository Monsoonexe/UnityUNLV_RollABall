using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpMoveVertical : MonoBehaviour
{
    // Determine how high it goes
 
    public AnimationCurve myCurve;


    //Use this for initialization
    private void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
{

    transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }

}
