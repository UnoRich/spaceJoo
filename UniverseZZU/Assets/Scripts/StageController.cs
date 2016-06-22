using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
	public Transform bulletPrefab;
	// Use this for initialization
	void Start () {
//		Transform bullet = Instantiate(bulletPrefab) as Transform;
//
//		Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
	}

	void OnCollisionEnter(Collision c)
	{
		Physics.IgnoreCollision(c.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
	}

	// Update is called once per frame
	void Update () {
	
	}

	void StageReset() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
