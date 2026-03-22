// Player Controller Script
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour{

    // Public variables player speed, and for the Text UI game objects
	public float f_horPlayAccel;
	public Text NumTotal;
	public Text wintext;

	// Private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private float inttotalcount;

	// Game Start
	void Start ()	{rb = GetComponent<Rigidbody>();inttotalcount = 0;SetCountText ();wintext.text = "";}
	void FixedUpdate ()
	{
		// Local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 variable, and assign X and Z to feature horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * f_horPlayAccel);
	}
	void OnTriggerEnter(Collider other) 
{
if (other.gameObject.CompareTag ("Pick Up"))
{	other.gameObject.SetActive (false);
		inttotalcount = inttotalcount + 1;
		SetCountText ();
}}

	//Counter UI setup/checker
    void SetCountText()
	{NumTotal.text = "Count: " + inttotalcount.ToString ();
		if (inttotalcount >= 12) 
{
			// Text value of 'winText'
			wintext.text = "You Win!";
}
}
}