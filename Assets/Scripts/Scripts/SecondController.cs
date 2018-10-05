using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SecondController : MonoBehaviour {

    public float speed;
	private Collider col; 
    private Rigidbody rb;
	public bool isInControl = false;
	public Text scoreText;
	public bool isGrounded = true;
	
	public PlayerController player1;
	public int totalScore;
	public Vector3 jump;
    public float jumpForce = 4.0f;
	
	public int pointvalue = 5; 
	public Vector3 startposition;

    void Start ()
    {
		startposition = transform.position;
		int totalScore = player1.totalScore;
        rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	void Update ()
	{
		totalScore = player1.totalScore;
		scoreText.text = "Score: " + totalScore.ToString();
		
	}

	void onCollisionStay()
	{
		
		isGrounded = true;
		
	}
	
    void FixedUpdate ()
    {
		
		if(this.isInControl)
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
			
			if(Input.GetKeyDown("l"))
			{
				isInControl = false;
				player1.isInControl = true;
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
			
			player1.totalScore += pointvalue;
			scoreText.text = totalScore.ToString();
			
		}
		
		else
		{
			
			return; 
		}
		
	}
	
}