using UnityEngine;
using System.Collections;

public class MissleController : MonoBehaviour {
	public GameObject explosion;

	private float speed = 25.0f;
	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "Cube") {
			Instantiate ( explosion, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation );
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
