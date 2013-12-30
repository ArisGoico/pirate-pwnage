using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	public int goldValue = 10;

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Ship") {
			PlayerGUI temp = other.transform.parent.gameObject.GetComponent<PlayerGUI>();
			if (temp != null) {
				temp.addGold(goldValue);
				GameObject.Destroy(this.gameObject);
			}
		}
	}
	

}
