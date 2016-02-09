using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	private List<Item> _items;
	public GameObject YellowKeyShow;
	public GameObject YellowKeyHide;

	Color YellowKeySpriteColorFull;
	Color YellowKeySpriteColorOpaque;

	void Start () {
		_items = new List<Item> ();
		YellowKeyShow.SetActive (false);
	}

	public bool ContainsItem(Item item){
		return _items.Contains (item);
	}

	public void AddItem(Item item){
		if (item.Type == Item.ItemType.Key) {
			ShowItem (item);
		}
		_items.Add (item);
	}

	public void ShowItem(Item item){
		switch (item.Name) {
		case Item.ItemName.YellowKey:
			YellowKeyHide.SetActive (false);
			YellowKeyShow.SetActive (true);
			break;
		default:
			break;
		}
	}

	public void HideItem(Item item){
		switch (item.Name) {
		case Item.ItemName.YellowKey:
			YellowKeyHide.SetActive (true);
			YellowKeyShow.SetActive (false);
			break;
		default:
			break;
		}
	}

	public void RemoveItem(Item item){
		_items.Remove (item);
		if (item.Type == Item.ItemType.Key && !_items.Contains(item)) {
			HideItem (item);
		}
	}



}

public struct Item{

	public ItemName Name;
	public ItemType Type;

	public Item(ItemName name, ItemType type){
		Name = name;
		Type = type;
	}

	public enum ItemType{
		Key,
		Power
	}

	public enum ItemName{
		YellowKey,
		RedKey,
		BlueKey,
		Cloud
	}
}

public static class StaticItems{
	public static Item YellowKey = new Item(Item.ItemName.YellowKey, Item.ItemType.Key);
}
