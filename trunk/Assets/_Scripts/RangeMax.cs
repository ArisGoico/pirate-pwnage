using UnityEngine;
using System.Collections;


public class RangeMax : MonoBehaviour {

	private Transform weapon;
	private ShipWeapon weaponScript;

	// Use this for initialization
	void Awake() {
		searchWeapon();
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Ship") {
			if (weaponScript == null) {
				searchWeapon();
			}
			if (weaponScript != null) {
				weaponScript.addTarget(other.gameObject);
//				Debug.Log("Target " + other.gameObject.name + " added = " + temp + ".");
			}
			else {
				Debug.LogError("The ship " + this.transform.parent.name + " has no weapon systems.");
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Ship") {
			if (weaponScript == null) {
				searchWeapon();
			}
			if (weaponScript != null) {
				weaponScript.delTarget(other.gameObject);
			}
			else {
				Debug.LogError("The ship " + this.transform.name + " has no weapon systems.");
			}
		}
	}

	private void searchWeapon() {
		foreach (Transform child in transform.parent) {
			if (child.tag == "Weapon") {
				weapon = child;
				weaponScript = weapon.GetComponent<ShipWeapon>();
			}
		}
	}
}
