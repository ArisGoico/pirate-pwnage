using UnityEngine;
using System.Collections;


public class ShipValues : MonoBehaviour {

	public float shipDrag = 1f;
	public float shipSpeed = 1f;
	public float shipMass = 1f;
	public float angularSpeed = 1f;
	public Transform placeholderWeapon;
	public Transform placeholderSkill;

	void Awake() {
		this.rigidbody.mass = shipMass;
		this.rigidbody.drag = shipDrag;
		foreach (Transform child in transform) {
			if (child.tag == "PlaceholderSkill") {
				placeholderSkill = child;
			}
			if (child.tag == "PlaceholderWeapon") {
				placeholderWeapon = child;
			}
		}
	}
}
