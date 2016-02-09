using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Animator animator;
	AudioSource audio;

	void Start () {
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		animator.SetBool ("IsTaken", true);
		audio.Play ();
		Destroy (this.GetComponent<BoxCollider2D> ());
		GameObject.Destroy (transform.parent.gameObject, .7f);
	}
}
