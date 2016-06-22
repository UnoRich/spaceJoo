using UnityEngine;
using System.Collections;

public class LazorController : MonoBehaviour {
	public Transform origin;
	LineRenderer lineRenderer;

	public float LineWidth; // use the same as you set in the line renderer.

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetWidth (.05f, .05f);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit[] hitObjs;
		Vector3 newPos = new Vector3( 0, 100, 0 );
		//Ray ray = new Ray (origin.position, new Vector3 (0, 1, 0));
		hitObjs = Physics.RaycastAll ( origin.position, new Vector3( 0, 1, 0 ), Mathf.Infinity );
		if ( hitObjs != null ) {
			foreach( RaycastHit hitObj in hitObjs ) {
				if (hitObj.transform.gameObject.tag == "Cube") {
					newPos = hitObj.point;
					break;
				}
			}
		}

		lineRenderer.SetPosition ( 0, origin.position );
		lineRenderer.SetPosition ( 1, newPos );
	}


}
