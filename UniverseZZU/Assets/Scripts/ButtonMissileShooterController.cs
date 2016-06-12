using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMissileShooterController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler {

	// Use this for initialization
	void Start () {
	
	}

	// 인터페이스 트리거 관련
	public void OnPointerDown(PointerEventData data)
	{
		GameObject.Find ("Player").GetComponent<PlayerController> ().shotMissle ();
	}

	public void OnPointerEnter(PointerEventData data)
	{
		
		print ("click");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
