using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public AudioClip soundClip;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			player.hud.AddItem (new Item(Item.ItemName.YellowKey, Item.ItemType.Key));
			AudioManager.Play (soundClip);
			GameObject.Destroy (this.gameObject);
		}
	}
}
