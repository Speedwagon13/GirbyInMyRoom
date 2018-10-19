using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour {


	[SerializeField]
	protected bool conditionMet = false;

	public bool ConditionMet {
		get {
			return conditionMet;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
