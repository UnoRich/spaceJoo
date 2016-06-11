using UnityEngine;
using System.Collections;

public class MissleController : MonoBehaviour {
	private float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Cube") {
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
			
		//print (c.gameObject.name);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 1, 0) * speed;
	}
}
