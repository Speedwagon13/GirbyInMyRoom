using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : Interactable {

	protected Mission mission;

	// Use this for initialization
	void Start () {
		base.Start();
		base.collisionBasedTrigger = true;
		mission = transform.parent.GetComponent<Mission>();

		UnityEvent killSelf = new UnityEvent();
		UnityEvent updateUI = new UnityEvent();
		killSelf.AddListener(SetInactive);
		updateUI.AddListener(UpdateUI);
		base.interactionManager.AddEvent(null, updateUI);
		base.interactionManager.AddEvent(null,killSelf);
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		
	}

	private void SetInactive() {
		gameObject.SetActive(false);
	}

	private void UpdateUI() {
		HUDActions.UpdateMission(mission);
	}
}
