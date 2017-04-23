using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombsController : MonoBehaviour {

	private Vector3 pos;
	private float speed;
	private Rigidbody2D rb2d;
	private float timeleft;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speed = 1f;
		timeleft =2f;
		Debug.Log (timeleft);
	}

	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
		Debug.Log (timeleft);
		if (timeleft <= 0) {
			int rand_index = Random.Range ((int)0,(int)4);
			Vector3[] move = {Vector3.up, Vector3.right, Vector3.down, Vector2.left};
			rb2d.velocity = speed*move [rand_index];
			Debug.Log (rb2d.velocity);
			timeleft = 2f;
		}
	}
}
