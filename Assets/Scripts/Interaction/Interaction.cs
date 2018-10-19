using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Interaction {

	[SerializeField]
	public Condition conditionObject;

	public UnityEvent action;

	public Interaction() {
		this.conditionObject = null;
		this.action = null;
	}
	public Interaction(Condition condition, UnityEvent action) {
		this.conditionObject = condition;
		this.action = action;
	}


	public bool CheckAndReact() {
		bool condResult = true;
		if (conditionObject == null) {
			Debug.Log("This interaction doesn't contain any condition, so it will trigger successful. ");
		} else {
			
			condResult = conditionObject.ConditionMet;
			
		}

		if (condResult) {
			action.Invoke();
			return true;
		}

		return false;
	}
}

[System.Serializable]
public class InteractionNonSequenced : Interaction {
	public bool repeat = true;
	private int timesRepeated = 0;

	public InteractionNonSequenced(Condition condition, UnityEvent action) {
		base.conditionObject = condition;
		base.action = action;
	}

	new public bool CheckAndReact() {
		bool condResult = true;
		if (base.conditionObject == null) {
			Debug.Log("This interaction doesn't contain any condition, so it will trigger successful. ");
		} else {
			condResult = base.conditionObject.ConditionMet;
		}

		if (condResult && (repeat || (timesRepeated<1))) {
			action.Invoke();
			timesRepeated++;
			return true;
		}

		return false;
	}

}
