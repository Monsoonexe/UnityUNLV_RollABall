using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //public GameObject player;
	//public GameObject player2;
	
	public PlayerController p;
	public SecondController p2;

    private Vector3 offset;

    void Start ()
    {
        //offset = transform.position - player.transform.position;
		offset = transform.position - p.transform.position;
    }
    
    void LateUpdate ()
    {
        //transform.position = player.transform.position + offset;
		if(p.isInControl)
		{
			transform.position = p.transform.position + offset;
		}
		
		else
		{
			transform.position = p2.transform.position + offset;
		}
    }
}

