using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour {

	public GameObject initShip;
	private GameObject ship;
	public GameObject initWeapon;
	private GameObject weapon;
	public GameObject initSkill;
	private GameObject skill;
	private ShipValues shipValues;
	private GameObject cam;
	private Vector3 camInitPos;
	private Transform placeholderShip;

	// Use this for initialization
	void Start() {
		if (initShip == null) {
			Debug.LogError("No initial ship was assigned to Player " + this.name + ". No controls initialized.");
			this.enabled = false;
		}

		foreach (Transform child in transform) {
			if (child.tag == "MainCamera") {
				cam = child.gameObject;
				camInitPos = cam.transform.position;
			}
			if (child.tag == "PlaceholderShip") {
				placeholderShip = child;
			}
		}
		changeShip(initShip);
		changeWeapon(initWeapon);
	}
	
	// Movement
	void Update() {
		Vector3 moveDir = Vector3.zero;
		moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (moveDir.magnitude > 0f) {
			ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, Quaternion.LookRotation(moveDir, Vector3.up), shipValues.angularSpeed);
		}
		ship.rigidbody.AddForce(moveDir.magnitude * ship.transform.forward * shipValues.shipSpeed);
		cam.transform.position = camInitPos + ship.transform.position;
	}

	public void changeShip(GameObject newShip) {
		if (ship != null) {
			placeholderShip = ship.transform;
		}
		GameObject.Destroy(ship);
		GameObject temp = Instantiate(newShip, placeholderShip.position, placeholderShip.rotation) as GameObject;
		ship = temp;
		ship.transform.parent = this.transform;
		shipValues = ship.GetComponent<ShipValues>();
	}

	public void changeWeapon(GameObject newWeapon) {
		GameObject.Destroy(weapon);
		GameObject temp = Instantiate(newWeapon, shipValues.placeholderWeapon.position, shipValues.placeholderWeapon.rotation) as GameObject;
		weapon = temp;
		weapon.transform.parent = ship.transform;
	}
}
