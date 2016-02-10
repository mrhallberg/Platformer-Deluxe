using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	Animator animator;
	public AudioClip soundClip;

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			animator.SetBool ("IsTaken", true);
			AudioManager.Play (soundClip);
			Destroy (this.GetComponent<BoxCollider2D> ());
			GameObject.Destroy (transform.parent.gameObject, .7f);
		}
	}
}
