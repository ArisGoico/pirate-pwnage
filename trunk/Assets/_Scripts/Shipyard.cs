using UnityEngine;
using System.Collections;

public class Shipyard : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Ship") {
			PlayerGUI temp = other.transform.parent.gameObject.GetComponent<PlayerGUI>();
			if (temp != null) {
				temp.setShipyard(true);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Ship") {
			PlayerGUI temp = other.transform.parent.gameObject.GetComponent<PlayerGUI>();
			if (temp != null) {
				temp.setShipyard(false);
			}
		}
	}
}
