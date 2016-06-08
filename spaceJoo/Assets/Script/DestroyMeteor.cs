using UnityEngine;
using System.Collections;

public class DestroyMeteor : MonoBehaviour {
	public float lifetime=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player") {
			Destroy (gameObject, lifetime);
		}

	}
}
