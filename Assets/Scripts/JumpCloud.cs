using UnityEngine;
using System.Collections;

public class JumpCloud : MonoBehaviour {

	public AudioClip soundClip;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			player.amountOfJumps++;
			AudioManager.Play (soundClip);
			player.hud.AddItem (new Item (Item.ItemName.Cloud, Item.ItemType.Power));
			GameObject.Destroy (this.gameObject);
		}
	}
}
