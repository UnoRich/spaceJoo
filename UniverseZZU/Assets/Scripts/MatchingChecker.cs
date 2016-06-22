using UnityEngine;
using System.Collections;

public class MatchingChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Solid").activeSelf) {
			print ("hi");
		}
	}
}
