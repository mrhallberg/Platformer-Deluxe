using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MonoBehaviour {
		
	public float moveSpeed;
	public float jumpForce;

	public bool isJumping = false;
	public HUD hud;

	public int amountOfJumps;
	public int jumps;
	public float direction;

	Animator animator;
	Rigidbody2D rigidbody;

	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		UpdateMovement ();
	}

	void UpdateMovement(){
		if (Input.GetButtonDown("Jump")) {
			if (jumps < amountOfJumps) {
				isJumping = true;
				animator.SetBool ("IsJumping", true);
				rigidbody.Sleep ();
				rigidbody.AddForce (new Vector2 (0, jumpForce));
				jumps++;
			}
		}
		float HorizontalInput = Input.GetAxisRaw ("Horizontal");
		if (HorizontalInput != 0) {
			if (isJumping) {
				animator.SetBool ("IsWalking", false);
			} else {
				animator.SetBool ("IsWalking", true);
			}
			if (HorizontalInput != direction) {
				direction *= -1;
				transform.localEulerAngles += Vector3.up * 180 * direction;
			}
			transform.position += new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
		} else {
			animator.SetBool ("IsWalking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Ground") {
			jumps = 0;
			isJumping = false;
			animator.SetBool ("IsJumping", false);
		}
	}
}
