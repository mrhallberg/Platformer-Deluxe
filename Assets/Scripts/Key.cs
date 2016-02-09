using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			print ("Key");
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			player.AddItem ("YellowKey");
			GameObject.Destroy (this.gameObject);
		}
	}
}
