﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gate : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Player player = collider.gameObject.GetComponentInParent (typeof(Player)) as Player;
			if (player.hud.ContainsItem(StaticItems.YellowKey)) {
				GameObject.Destroy (this.gameObject);
				player.hud.RemoveItem (StaticItems.YellowKey);
			}
		}
	}
}