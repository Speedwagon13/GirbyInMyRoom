using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	CameraMain cam;

	public static PlayerController playerController;

	BallMove ball;

	void Start () {
		playerController = GetComponent<PlayerController>();
		cam = GetComponentInChildren<CameraMain>();
		ball = GetComponentInChildren<BallMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LockCameraToPoint(Transform point) {
		ball.LockBallPosition(true);
		cam.LockCameraInFrontOfPoint(point);
	}

	public void UnlockCamera() {
		cam.UnlockCamera();
		ball.LockBallPosition(false);
	}

	public void LockDialogCamera(Transform point) {

	}
}
