using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitch : MonoBehaviour {

	public enum Menu{Main, Settings, Credits};

	public GameObject main, settings, credits;
	public float duration = 0.5f;

	GameObject destination;
	private Vector2 containerPathVector, containerSourcePosition;
	private RectTransform rt;
	private RectTransform currentMenuTransform;
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
		currentMenuTransform = main.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch(int destination) {

		switch(destination) {
			case 0:
				this.destination = main;
				break;
			case 1:
				this.destination = settings;
				break;
			case 2:
				this.destination = credits;
				break;
		}

		//current pos - destination pos bc these positions are inside the rect transform
		//that we actually intend on moving, so they must go the opposite direction
		containerPathVector = currentMenuTransform.anchoredPosition - this.destination.GetComponent<RectTransform>().anchoredPosition;
		containerSourcePosition = rt.anchoredPosition;
		StartCoroutine(AnimationUtilities.MoveUI(rt, containerSourcePosition, containerPathVector, duration, AnimationUtilities.CurveType.EaseInOut));
		currentMenuTransform = this.destination.GetComponent<RectTransform>();
	}
}
