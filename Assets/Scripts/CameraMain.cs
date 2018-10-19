using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour {

	public Transform player;
	public Transform room;

	public Transform girbyModel;

	public float cameraLockTime = 0.3f;

	private Vector3 offset, newCamPos, origCamPos, startLookPoint;
	private float distance;

	private bool locked = false;
	private Transform point;
	private Quaternion origCamRot;
	void Start () {
		offset = transform.position - player.position;
		distance = offset.magnitude;
		//transform.LookAt(player, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if (Input.GetKeyDown(KeyCode.E) && Interactable.inRange != null) {
			if (Interactable.inRange is Bug) {
                if (Interactable.inRange is Kabuto)
                    ((Kabuto)Interactable.inRange).TriggerInteractable(); // hacky
                else
                    ((Bug)Interactable.inRange).TriggerInteractable();
			} else {
				Interactable.inRange.TriggerInteractable();

			}
		}

		Transform xRot = transform.parent;
		if (!locked || (origCamRot == transform.rotation && origCamPos == transform.position)) {
			player.Rotate(Vector3.up*1.5f*Input.GetAxis("Mouse X"));
			xRot.Rotate(Vector3.right*1.5f*Input.GetAxis("Mouse Y"));
			locked = false;
		}
	}


	public void LockCameraInFrontOfPoint(Transform point) {
		locked = true;
		this.point = point;

		startLookPoint = transform.forward*2;

		Vector3 newCameraPosition = point.forward*1.5f + point.position;

		if (Vector3.Distance(newCameraPosition, transform.position) > Vector3.Distance(point.position - point.forward*1.5f, transform.position)) {
			newCameraPosition = point.position - point.forward*1.5f;
		}

		origCamPos = transform.position;
		origCamRot = transform.rotation;
	
		Quaternion endLookRot = Quaternion.LookRotation(point.position-newCameraPosition);
		Quaternion startLookRot = transform.rotation;

		float lookRotDistance = Vector3.Distance(endLookRot.eulerAngles.normalized, startLookRot.eulerAngles.normalized);
		Debug.Log(endLookRot.eulerAngles + " : " + startLookRot.eulerAngles.normalized);
		float distance = Vector3.Distance(transform.position, newCameraPosition);
		//float rotDistance = Quaternion.LookRotation
		
		SetCameraPositionRotation(newCameraPosition, endLookRot);
	}

	public void UnlockCamera() {	
		SetCameraPositionRotation(origCamPos, origCamRot);			
	}

	private void SetCameraPositionRotation(Vector3 newCameraPosition, Quaternion newRotation) {
		StartCoroutine(AnimationUtilities.MoveTo3D(transform, newCameraPosition, cameraLockTime));
		StartCoroutine(AnimationUtilities.RotateTo3D(transform, newRotation, cameraLockTime));	
	}
}
