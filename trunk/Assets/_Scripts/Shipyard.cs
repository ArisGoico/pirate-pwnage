using UnityEngine;
using System.Collections;

public class Shipyard : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Ship") {
			Movement temp = other.transform.parent.gameObject.GetComponent<Movement>();
			if (temp != null) {
				temp.setShipyard(true);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Ship") {
			Movement temp = other.transform.parent.gameObject.GetComponent<Movement>();
			if (temp != null) {
				temp.setShipyard(false);
			}
		}
	}
}
