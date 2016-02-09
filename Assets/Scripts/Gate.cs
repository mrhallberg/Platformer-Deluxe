using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gate : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			print ("Gate");
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			if (player.items.Contains("YellowKey")) {
				GameObject.Destroy (this.gameObject);
				player.RemoveItem ("YellowKey");
			}
		}
	}
}
