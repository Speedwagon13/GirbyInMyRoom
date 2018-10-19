using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	
	Rigidbody rb;
	public Transform positionDummy;
	public float speed = 8f;

	public float jumpSpeed = 20f;
	public float stopDrag = 4f;

	private Vector3 gravityDirection = Vector3.down;
	private bool falling = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update() {
		float fwd = Input.GetAxis("Vertical");
		float strafe = Input.GetAxis("Horizontal");

		Vector3 movement = Camera.main.transform.forward*fwd;
		movement += Camera.main.transform.right*strafe;

		if (Input.GetKeyDown(KeyCode.Space)) {
			movement = -gravityDirection * jumpSpeed;
			Physics.gravity = Vector3.down * 9.81f;

			rb.drag = 0;
			rb.AddForce(movement*speed);
			falling = true;
		} else if (!falling) {
			rb.drag = (movement == Vector3.zero ) ? stopDrag : 0;
			rb.AddForce(movement*speed);
		}

		if (rb.velocity.magnitude >= 2.5 && !falling) {
			rb.velocity = rb.velocity.normalized * 2.5f;
		}

		positionDummy.position = transform.position;
	}

	public void LockBallPosition(bool toLock) {
		if(toLock) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
		} else {
			rb.constraints = RigidbodyConstraints.None;

		}
	}

	public void OnCollisionEnter(Collision col) {
		if (col.gameObject.layer == 9) {
			Debug.Log(col.transform.name);
			gravityDirection = -col.contacts[0].normal;
			Physics.gravity = 9.81f* gravityDirection;
			falling = false;
			Debug.Log(col.contacts[0].normal);
		}
		
	}

	
}
