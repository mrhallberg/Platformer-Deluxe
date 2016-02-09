using UnityEngine;
using System.Collections;

public class JumpCloud : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			player.amountOfJumps++;
			GameObject.Destroy (this.gameObject);
		}
	}
}
