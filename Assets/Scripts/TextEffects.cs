using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffects : MonoBehaviour {

	public int typeSpeed = 20;
	public string text;

	TextMeshProUGUI tm;

	private int textLength;
	private int textIndexPosition = 0;

	// Use this for initialization
	void Start () {	
		
	}
	void Awake()
	{
		tm = GetComponent<TextMeshProUGUI>();
		if (text.Length == 0) {
			text = tm.text;
		}
	}

	void OnEnable() {
		textIndexPosition = 0;
		tm.text = "";
		textLength = text.Length;
	}

	public void ChangeTypeSpeed(int speed) {
		typeSpeed = speed;
	}

	public void TriggerText(string txt) {
		text = txt;
		textIndexPosition = 0;
		tm.text = "";
		textLength = text.Length;
		TriggerText();
	}
	public void TriggerText() {
		InvokeRepeating("UpdateText", 0f, 1.0f/typeSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void UpdateText() {
		if (!gameObject.activeInHierarchy) {
			CancelInvoke();
			return;
		}

		tm.text += text[textIndexPosition];

		textIndexPosition++;
		if (textIndexPosition == textLength) {
			CancelInvoke();
		}
	}
}
