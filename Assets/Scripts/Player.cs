using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public bool isJumping = false;

	Animator animator;
	Rigidbody2D rigidbody;


	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		UpdateMovement ();
		CheckForOutOfBounds ();
	}

	void CheckForOutOfBounds(){
		if (transform.position.y < -2) {
			SceneManager.LoadScene ("Level 1");
		}
	}

	void UpdateMovement(){
		if (Input.GetButtonDown("Jump")) {
			if (!isJumping) {
				isJumping = true;
				rigidbody.AddForce (new Vector2 (0, jumpForce));
			}
		}
		if (Input.GetAxisRaw("Horizontal") != 0) {
			animator.SetBool ("IsWalking", true);
			transform.position += new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
		} else {
			animator.SetBool ("IsWalking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		isJumping = false;
	}
}
