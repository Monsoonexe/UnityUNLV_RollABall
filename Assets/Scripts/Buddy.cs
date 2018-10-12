using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;

    private float timer = 0;
    public float forceMult;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       
       if (Input.GetKey("space") && timer <= 7f)
        {
            Vector3 dir = new Vector3(player.transform.position.x - gameObject.transform.position.x, 0, player.transform.position.z - gameObject.transform.position.z);

            rb.AddForce(dir * forceMult);

            timer += Time.deltaTime;
        }

        if (Input.GetKey("space") == false && timer >= 0)
        {
            timer -= Time.deltaTime * 1.5f;

        }
        else if (timer < 0) { timer = 0; }
       

    }
}