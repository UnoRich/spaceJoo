using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class GameController : MonoBehaviour {
	public Text textSuccess;
	private static float delayTime = 2.0f;
	private static float textDelayTime = 1.5f;
	// Use this for initialization
	void Start () {
		GameObject.Find ( "Solution" ).SetActive ( false );
		GameObject.Find ( "ButtonBack" ).SetActive ( false );

		textSuccess.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//solution과 스텝을 체크하는 method
	public void MatchCheck() {
		
		//solution
		Transform solutionParent = GameObject.Find ("SolutionWrapper").transform.FindChild ("Solution").FindChild("SolutionComponent");
		Transform[] solution = GameObject.Find ("SolutionWrapper").transform.FindChild ("Solution").FindChild("SolutionComponent").GetComponentsInChildren<Transform>();

		//stage
		Transform stageParent = GameObject.Find ("Stage").GetComponent<Transform> ();
		Transform[] stage = GameObject.Find ("Stage").GetComponentsInChildren<Transform> ();

		stageParent.rotation = new Quaternion (0, 0, 0, 0);
		solutionParent.rotation = new Quaternion (0, 0, 0, 0);

		bool result = true;

		if ( solution.Length != stage.Length  ) {
			textSuccess.text = "Fail.\n Try again.";
			Invoke( "ClearText", textDelayTime );

			return ;
		}

		for (int rZ = 0; rZ < 4; rZ++) {
			for (int rX = 0 ; rX < 4 ; rX++) {
				for (int rY = 0; rY < 4; rY++) {
					result = true;

					foreach (Transform solCube in solution) {
						//remove self
						if (solCube.tag != "Cube") {
							continue;
						}
						bool find = false;

						foreach (Transform stgCube in stage) {
							//remove self
							if (stgCube.tag != "Cube") {
								continue;
							}

							Vector3 x1 = solutionParent.TransformPoint( solCube.localPosition ) - solutionParent.position;
							Vector3 x2 = stageParent.TransformPoint( stgCube.localPosition ) - stageParent.position;
							if (
								Mathf.Abs( x1.x - x2.x ) <= .5f &&
								Mathf.Abs( x1.y - x2.y ) <= .5f &&
								Mathf.Abs( x1.z - x2.z ) <= .5f ) {

								find = true;
								break;
							}
						}

						if (!find) {
							result = false;
							break;
						}
					}

					if ( result ) {
						break;
					}

					stageParent.Rotate ( new Vector3 (0, 90, 0));
				}

				if ( result ) {
					break;
				}
				stageParent.Rotate ( new Vector3 (90, 0, 0) );

			}

			if ( result ) {
				break;
			}

			stageParent.Rotate ( new Vector3 (0, 0, 90) );
		}
			
		if (result) {
			textSuccess.text = "Success!";
			Invoke( "ClearText", textDelayTime );
			StartCoroutine ( "MoveNextScene" );
		} else {
			textSuccess.text = "Fail.\n Try again.";
			Invoke( "ClearText", textDelayTime );
		}
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

	public void StageReset() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	private IEnumerator MoveNextScene()
	{
		yield return new WaitForSeconds( delayTime );

		int next = int.Parse( Regex.Replace( SceneManager.GetActiveScene ().name, "[^0-9]", "") );
		next++;
		SceneManager.LoadScene( "Stage" + next, LoadSceneMode.Single );
	}

	private void ClearText( )
	{
		textSuccess.text = "";
	}

}
