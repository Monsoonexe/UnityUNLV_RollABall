using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    public GameObject player;

    public float forceMult;
    private float timer = 0f;
    public int agro;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<Collider>();
        
    }

    void FixedUpdate ()
    {
        timer += Time.deltaTime;

        if (timer >= 5f && timer <= 5f + agro)
        {
            Vector3 dir = new Vector3(player.transform.position.x - gameObject.transform.position.x, 0, player.transform.position.z - gameObject.transform.position.z);

            rb.AddForce(dir * forceMult);
        }
        else if (timer >= 5f + agro)
        {
            timer = 0f;
            agro++;
        }
    }

    //Debug
    void Update()
    { if (Input.GetKey("[")) { forceMult--; } if (Input.GetKey("]")) { forceMult++; } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Buddy"))
        {
            timer = 0;
            agro = 2;
        }
        else
        {
            return;
        }
    }
}
