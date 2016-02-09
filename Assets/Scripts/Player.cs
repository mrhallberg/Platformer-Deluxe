using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MonoBehaviour {
		
	public float moveSpeed;
	public float jumpForce;

	public bool isJumping = false;
	public List<string> items;

	public int amountOfJumps;
	public int jumps = 0;

	public GameObject yellowKey;

	Animator animator;
	Rigidbody2D rigidbody;


	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
		items = new List<string> ();
		yellowKey.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void AddItem(string item){
		switch (item) {
		case "YellowKey":
			yellowKey.GetComponent<SpriteRenderer> ().enabled = true;
			items.Add ("YellowKey");
			break;
		default:
			break;
		}
	}

	public void RemoveItem(string item){
		switch (item) {
		case "YellowKey":
			yellowKey.GetComponent<SpriteRenderer> ().enabled = false;
			items.Remove ("YellowKey");
			break;
		default:
			break;
		}
	}

	void Update () {
		UpdateMovement ();
	}

	void UpdateMovement(){
		if (Input.GetButtonDown("Jump")) {
			if (jumps < amountOfJumps) {
				isJumping = true;
				rigidbody.AddForce (new Vector2 (0, jumpForce));
				jumps++;
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
		if (collider.gameObject.tag == "Ground") {
			jumps = 0;
		}
	}
}
