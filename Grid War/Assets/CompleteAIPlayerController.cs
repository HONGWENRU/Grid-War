using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CompleteAIPlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb2d;
	private double xLimit = 10.0;
	private double yLimit = 10.0;
	private double xTotal = 0.0;
	private double yTotal = 0.0;
	private float originX;
	private float originY;
	private Vector3 direction = Vector3.up;
	private int directionIndex = 0;
	private Vector3[] directions = {Vector3.up, Vector3.right, Vector3.down, Vector3.left};
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		this.originX = transform.position.x;
		this.originY = transform.position.y;

	}

	// Update is called once per frame
	void Update () {
		var amttomove = speed * Time.deltaTime;

		direction = directions [directionIndex];
		if (directionIndex % 2 == 0) {
			yTotal += (amttomove * direction).y;
			if (yTotal > yLimit) {
				directionIndex += 1;
				yTotal = 0;
			}
		}

		if (directionIndex % 2 == 1) {
			xTotal += (amttomove * direction).x;
			if (xTotal > xLimit) {
				directionIndex += 1;
				xTotal = 0;
			}
		}


		transform.Translate(this.direction * amttomove);
	}

	void GenerateRandomDirection()
	{
		Vector2 v2  = Random.insideUnitCircle * 2;
		this.direction = new Vector3(v2.x, v2.y, 0.0f);
	}
		

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

			//Add one to the current value of our count variable.
			this.speed *= 1.1f;
			transform.localScale *= 1.1f;
			//Update the currently displayed count by calling the SetCountText function.
		}

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			var newSpeed = other.gameObject.GetComponent<CompletePlayerController> ().speed;
			if (speed.CompareTo (newSpeed) > 0) {
				other.gameObject.SetActive (false);
			} else {
				Destroy (transform.root.gameObject);
			}
		} else if (other.gameObject.CompareTag("Maze")) {
			directionIndex = (directionIndex + 2) % 4;
			xTotal = 0;
			yTotal = 0;
		}
	}

}
