using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtilities {
	public enum CurveType {EaseIn, EaseOut, EaseInOut, Linear};

	public static IEnumerator MoveUITo(RectTransform rect, Vector2 startPosition, Vector2 endPosition, float duration, CurveType type) {
		Vector2 delta = endPosition - startPosition;
		float dist = delta.magnitude;
		Vector2 dir = delta.normalized;
		rect.anchoredPosition = startPosition;
		Vector2 startPos = startPosition;
		float currentTime = 0.0f;
		float currentDist = 0.0f;
		
		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentDist = SelectCurveType(type, currentTime, 0, dist, duration);
			if (currentDist >= dist) {
				rect.anchoredPosition = startPos + dist*dir;
			} else {
				rect.anchoredPosition = startPos + currentDist*dir;
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public static IEnumerator MoveUITo(RectTransform rect, Vector2 endPosition, float duration, CurveType type) {
		Vector2 delta = endPosition - rect.anchoredPosition;
		float dist = delta.magnitude;
		Vector2 dir = delta.normalized;
		Vector2 startPos = rect.anchoredPosition;
		float currentTime = 0.0f;
		float currentDist = 0.0f;
		
		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentDist = SelectCurveType(type, currentTime, 0, dist, duration);
			if (currentDist >= dist) {
				rect.anchoredPosition = startPos + dist*dir;
			} else {
				rect.anchoredPosition = startPos + currentDist*dir;
			}
			yield return new WaitForFixedUpdate();
		}
	}


	/*
		If you want to move UI from a separate position than it actually starts at.
	 */
	public static IEnumerator MoveUI(RectTransform rect, Vector2 startPosition, Vector2 delta, float duration, CurveType type) {
		float dist = delta.magnitude;
		Vector2 dir = delta.normalized;
		rect.anchoredPosition = startPosition;
		Vector2 startPos = rect.anchoredPosition;
		float currentTime = 0.0f;
		float currentDist = 0.0f;

		
		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentDist = SelectCurveType(type, currentTime, 0, dist, duration);
			if (currentDist >= dist) {
				rect.anchoredPosition = startPos + dist*dir;
			} else {
				rect.anchoredPosition = startPos + currentDist*dir;
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public static IEnumerator MoveUI(RectTransform rect, Vector2 delta, float duration, CurveType type) {
		float dist = delta.magnitude;
		Vector2 dir = delta.normalized;
		Vector2 startPos = rect.anchoredPosition;
		float currentTime = 0.0f;
		float currentDist = 0.0f;

		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentDist = SelectCurveType(type, currentTime, 0, dist, duration);
			if (currentDist >= dist) {
				rect.anchoredPosition = startPos + dist*dir;
			} else {
				rect.anchoredPosition = startPos + currentDist*dir;
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public static IEnumerator MoveTo3D(Transform position, Vector3 newPosition, float duration) {
		Vector3 delta = newPosition - position.position;
		float dist = delta.magnitude;
		Vector3 dir = delta.normalized;

		Vector3 startPos = position.position;
		float currentTime = 0.0f;
		float currentDist = 0.0f;

		
		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentDist = SelectCurveType(CurveType.Linear, currentTime, 0, dist, duration);
			if (currentDist >= dist) {
				position.position = startPos + dist*dir;
			} else {
				position.position = startPos + currentDist*dir;
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public static IEnumerator RotateTo3D(Transform transform, Quaternion newRotation, float duration) {

		Quaternion startRot = transform.rotation;
		float currentTime = 0.0f;
		float currentT = 0.0f;
		
		while( currentTime <= duration) {
			currentTime += Time.deltaTime;
			currentT = SelectCurveType(CurveType.Linear, currentTime, 0, 1, duration);
			if (currentT >= 1) {
				transform.rotation = newRotation;
			} else {
				transform.rotation = Quaternion.Slerp(startRot, newRotation, currentT);
			}
			yield return new WaitForFixedUpdate();
		}
	}

	public static float EaseIn(float time, float startValue, float totalDistance, float duration) {
		time /= duration;
		return totalDistance*time*time + startValue;
	}

	public static float EaseOut(float time, float startValue, float totalDistance, float duration) {
		time /= duration;
		return (-totalDistance)*time*(time-2) + startValue;
	}

	public static float EaseInOut(float time, float startValue, float totalDistance, float duration) {
		time /= (duration/2);
		if (time < 1) {
			return (totalDistance/2)*time*time + startValue;
		}

		time--;
		return (-totalDistance/2)*(time*(time-2) - 1) + startValue;
	}

	//time and duration are in sec
	//
	public static float LinearTween(float time, float startValue, float totalDistance, float duration) {
		return totalDistance*time/duration + startValue;
	}

	private static float SelectCurveType(CurveType type, float time, float startValue, float totalDistance, float duration) {
		switch(type) {
			case CurveType.EaseIn: return EaseIn(time, startValue, totalDistance, duration);
			case CurveType.EaseOut: return EaseOut(time, startValue, totalDistance, duration);
			case CurveType.EaseInOut: return EaseInOut(time, startValue, totalDistance, duration);
			case CurveType.Linear: return LinearTween(time, startValue, totalDistance, duration);
		}
		return 0;
	}

}
