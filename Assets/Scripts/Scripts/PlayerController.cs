using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public float speed;
	private Collider col; 
    private Rigidbody rb;
	public bool isInControl = true;
	public Text scoreText;
	public int totalScore = 0;
	public bool isGrounded = true;
	
	public SecondController player2;
	public Vector3 jump;
    public float jumpForce = 4.0f;
	
	public int pointvalue = 5; 
	public Vector3 startposition;

    void Start ()
    {
		startposition = transform.position;
        rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	void Update ()
	{
		//totalScore = player2.totalScore;
		scoreText.text = "Score: " + totalScore.ToString();
		
	}

	void onCollisionStay()
	{
		
		isGrounded = true;
		
	}
	
    void FixedUpdate ()
    {
		
		if(isInControl)
		{
			if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
			{
			
				rb.AddForce(jump * jumpForce, ForceMode.Impulse);
				isGrounded = false;
			
			}
		
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			rb.AddForce (movement * speed * 1.4f);
			
			if(Input.GetKeyDown("m"))
			{
				isInControl = false;
				player2.isInControl = true;
			}
			
		}
	}
	
	
	
	private void OnCollisionEnter (Collision collision)
	{
		
		if(collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
		
		if(collision.gameObject.CompareTag("Collectible"))
		{
			//destroy pick up and adjust score 
			Destroy(collision.gameObject);
			
			totalScore += pointvalue;
			scoreText.text = totalScore.ToString();
			
		}
		
		
		else
		{
			
			return; 
		}
		
	}
	
}