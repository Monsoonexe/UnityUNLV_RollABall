/// Author: Name
/// Date: Date
/// Description: What program does
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHoleBehavior : MonoBehaviour
{
    public GameManager gameManager;
    public int scoreGiven = 10;
    public float thrustPower = 20;
    // Use this for initialization
    void Start()
    {
       // if (gameManager == null) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    /// <summary>
    /// If a sphere goes through, force it out the way it came
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Rigidbody>().AddForce(0, 0, -thrustPower, ForceMode.Impulse);
    }
    

    /// <summary>
    /// If made all the way through, WIP: add to score and destroy obstacle
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Buddy"))
        {
            //gameManager.AddPoints(scoreGiven);
            Destroy(transform.parent.gameObject);
        }
            
    }
    // Update is called once per frame
    void Update()
    {

    }
}
