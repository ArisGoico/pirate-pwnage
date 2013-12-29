using UnityEngine;
using System.Collections;


public class RangeMax : MonoBehaviour {

	private Transform weapon;
	private ShipWeapon weaponScript;

	// Use this for initialization
	void Awake() {
		weaponScript = this.transform.parent.GetComponent<ShipWeapon>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Ship") {
			if (weaponScript != null) {
				weaponScript.addTarget(other.gameObject);
			}
			else {
				Debug.LogError("The ship " + this.transform.parent.name + " has no weapon systems.");
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Ship") {
			if (weaponScript != null) {
				weaponScript.delTarget(other.gameObject);
			}
			else {
				Debug.LogError("The ship " + this.transform.name + " has no weapon systems.");
			}
		}
	}
}
