using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	private float maxSpeed = 5f;
	private Vector3 input;
	private Vector3 input2;
	private Vector3 spawn;
	Rigidbody rbody;
	public GameObject deathParticles;
	// Use this for initialization
	void Start () {
		spawn = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		rbody = GetComponent<Rigidbody>();
		input = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis("Vertical"));
		input2 = new Vector3 (0, Input.GetAxis ("Fire1"), 0);
		if (rbody.velocity.magnitude < maxSpeed) {
			rbody.AddForce(input * moveSpeed);
			rbody.AddForce (input2 * moveSpeed * 10);
		}


		if (transform.position.y < -2 || transform.position.y>10) {
			Die ();
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy") {
			Die ();
		}
		else if (other.transform.tag == "Meteor") {
			Die ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Goal") {
			GameManager.CompleteLevel(); 
		}
	}

	void Die()
	{
		Instantiate (deathParticles, transform.position, Quaternion.identity);
		rbody.velocity = Vector3.zero;
		rbody.angularVelocity = Vector3.zero; 
		transform.position = spawn;

	}
}
