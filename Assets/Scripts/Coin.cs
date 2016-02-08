using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		animator.SetBool ("IsTaken", true);
		GameObject.Destroy (transform.parent.gameObject, .8f);
	}
}
