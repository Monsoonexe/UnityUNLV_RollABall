using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    private static int nextKeyID = 0; // start at 0
    private int keyID;
    public GameObject door;

    Key()
    {
        this.keyID = nextKeyID++; // assign, then increment by 1
    }
    
    private int GetKeyID()
    {
        return this.keyID;
    }

}
