using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float thrust;
	public float torque;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private Renderer rend;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;

		SetCountText ();
		winText.text = "";

		rend = GetComponent<Renderer> ();
		rend.enabled = false;
	}

	void FixedUpdate () {
		// forward and backward translate, left and right rotate

		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);

		rb.AddRelativeForce (movement * thrust);
		rb.AddRelativeTorque (Vector3.up * torque * moveHorizontal);

		if (count == 12) {
			DisplayWinText ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count ++;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
	}

	void DisplayWinText() {
		winText.text = "YOU HAVE WON!!!";
	}

}
