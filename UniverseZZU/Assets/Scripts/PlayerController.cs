using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public GameObject shot;
	public Transform firePosition;

	private GameObject focusObj = null;
	private float focusx;
	private float focusy;
	private float focusz;
	private float moveRatio = 200.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
		{
			focusObj = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, Mathf.Infinity))

			{
				focusObj=hit.transform.gameObject;
			}
		}


		if(focusObj && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Moved && focusObj.tag == "Player")
		{
			focusx= Input.GetTouch(0).deltaPosition.x / moveRatio;
			focusz= 0;
			focusy= Input.GetTouch(0).deltaPosition.y / moveRatio;

//			Vector3 pos =  new Vector3( focusx, 0, 0 );
//			focusObj.transform.position += pos;
			focusObj.transform.Translate ( focusx, 0, 0);

		}


		if(focusObj && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			focusObj=null;
		}


	}

	public void shotMissle() {
		print ("shot");
		Instantiate (shot, firePosition.position, firePosition.rotation);
	}


	public void StageReset() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
