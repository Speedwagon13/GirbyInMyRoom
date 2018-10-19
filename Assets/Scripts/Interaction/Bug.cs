using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : Interactable {
	// Use this for initialization
	private bool inDialogue = false;

	new void Start () {
		base.Start();
		base.collisionBasedTrigger = false;
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
	}

	public new void TriggerInteractable() {
		//idk how this is rly gonna work yet
		base.TriggerInteractable();
		Debug.Log("BUG TRIGGERED");
	}
}
