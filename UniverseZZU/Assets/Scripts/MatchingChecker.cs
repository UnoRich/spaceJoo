using UnityEngine;
using System.Collections;

public class MatchingChecker : MonoBehaviour {

	static int[] cubeArr = new int[27];
	static int[] cubeArr2 = new int[27];
	string sb;
	// Use this for initialization
	void Start () {
		for (int i = 1; i < 28; i++)
		{
			sb = "solution ";
			string temp = i.ToString();
			sb += temp;
			if (GameObject.Find(sb) !=null) {
				cubeArr[i-1] =1;
			}
			else{
				cubeArr[i-1] =0;
			}
		}
		for (int i = 1; i < 28; i++)
		{
			sb = "Solid ";
			string temp = i.ToString();
			sb += temp;
			if (GameObject.Find(sb) !=null) {
				cubeArr2[i-1] =1;
				//print("CubeArr " + i +" = " + "1");
			}
			else{
				cubeArr2[i-1] =0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
	bool Check(){
		bool a = true;
		for (int i = 0; i < 27; i++) {
			if (cubeArr [i] == 1) {
				if (cubeArr2 [i] == 0) {
					a = false;
				}
			} else {
				if (cubeArr2 [i] == 1) {
					a = false;
				}
			}
		}
		return a;
	}

	public void UpdateCube (Collision c){
		string name = c.gameObject.name.Substring(6);
		int a = int.Parse(name);
		cubeArr2 [a - 1] = 0;
		print("cube update "+ a +" destroyed");
		bool b = Check ();	
		if (b) {
			print ("success");
		}
	}
}
