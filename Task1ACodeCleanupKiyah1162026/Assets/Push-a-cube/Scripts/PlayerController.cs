

//Push-A-Cube Player Controller

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour {

    // Public variables for player speed, and for the Text UI game objects
    [SerializeField]
    public float f_horPlayAccel;
	public Text NumTotal;
	public Text wintext;

	// Private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private float inttotalcount;
    private bool gameWon = false;

    void Start ()	{rb = GetComponent<Rigidbody>();inttotalcount = 0;SetCountText ();wintext.text = "";}
    void FixedUpdate()
    {
        // stops all movement once player wins the game
        if (gameWon) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * f_horPlayAccel);
    }

    void OnTriggerEnter(Collider other) 
	{

	if (other.gameObject.CompareTag ("Pick Up"))
		{			
			other.gameObject.SetActive (false);
			inttotalcount = inttotalcount + 1;
			SetCountText ();
		}
	}

    void SetCountText()
    {
        NumTotal.text = "Count: " + inttotalcount.ToString();

        if (inttotalcount >= 12)
        {
            wintext.text = "You Win!";
            gameWon = true;

            // Stops the player from moving after winning
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}