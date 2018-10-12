using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBehavior : MonoBehaviour {
    PlayerController userScript;
    public int requiredScoreToDestroy;
    void Start()
    {
        userScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }
    void Update()
    {
        if (userScript.scoreCount >= requiredScoreToDestroy)
        {
            gameObject.SetActive(false);
        }
        
    }
}
