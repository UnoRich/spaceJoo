﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject.Find ( "Solution" ).SetActive ( false );
		GameObject.Find ( "ButtonBack" ).SetActive ( false );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//solution과 스텝을 체크하는 method
	bool MatchCheck() {
		return true;
	}

	//solution을 보여주는 함수
	public void ShowSolution() {
		GameObject.Find ( "SolutionWrapper" ).transform.FindChild( "Solution" ).gameObject.SetActive ( true );
		GameObject.Find ( "Canvas" ).transform.FindChild( "ButtonBack" ).gameObject.SetActive ( true );
		GameObject.Find ( "Canvas" ).transform.FindChild( "ButtonSolution" ).gameObject.SetActive (false);
		GameObject.Find ( "Canvas" ).transform.FindChild( "ButtonShot" ).gameObject.SetActive (false);
	}

	public void ShowStage() {
		GameObject.Find ( "Solution" ).SetActive ( false );
		GameObject.Find ( "ButtonBack" ).SetActive (false);
		GameObject.Find ( "Canvas" ).transform.FindChild( "ButtonSolution" ).gameObject.SetActive ( true );
		GameObject.Find ( "Canvas" ).transform.FindChild( "ButtonShot" ).gameObject.SetActive (true);
	}

}
