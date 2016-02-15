using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	private List<Item> _items;
	public GameObject YellowKeyShow;
	public GameObject YellowKeyHide;
	public GameObject CloudShow;
	public GameObject CloudHide;

	void Start () {
		_items = new List<Item> ();
		YellowKeyShow.SetActive (false);
		CloudShow.SetActive (false);
		Vector3 TopMiddle = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.95f, 0));
		TopMiddle.z += 10;
		YellowKeyShow.transform.position = TopMiddle - Vector3.left * 0.5f;
		YellowKeyHide.transform.position = TopMiddle - Vector3.left * 0.5f;
		CloudHide.transform.position = TopMiddle + Vector3.left * 0.5f;
		CloudShow.transform.position = TopMiddle + Vector3.left * 0.5f;
	}

	public bool ContainsItem(Item.ItemName itemName){
		return _items.Exists (item => itemName == item.Name);
	}

	public void AddItem(Item item){
		ShowItem (item);
		_items.Add (item);
	}

	private void ShowItem(Item item){
		switch (item.Name) {
		case Item.ItemName.YellowKey:
			YellowKeyHide.SetActive (false);
			YellowKeyShow.SetActive (true);
			break;
		case Item.ItemName.Cloud:
			CloudShow.SetActive (true);
			CloudHide.SetActive (false);
			break;
		default:
			break;
		}
	}

	private void HideItem(Item item){
		switch (item.Name) {
		case Item.ItemName.YellowKey:
			YellowKeyHide.SetActive (true);
			YellowKeyShow.SetActive (false);
			break;
		case Item.ItemName.Cloud:
			CloudShow.SetActive (false);
			CloudHide.SetActive (true);
			break;
		default:
			break;
		}
	}

	public void RemoveItem(Item.ItemName itemName){
		Item currentItem = _items.Find (i => itemName == i.Name);
		_items.Remove (currentItem);
		HideItem (currentItem);
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
