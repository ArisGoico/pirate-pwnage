using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour {

	//Internal values for the instantiated objects
	private GameObject ship;
	private GameObject weapon;
	private GameObject skill;

	//Variables of the ship (life, speed, etc.)
	private ShipValues shipValues;

	//Camera
	private GameObject cam;
	private Vector3 camInitPos;

	//General private variables
	private Transform placeholderShip;				//Placeholder for the instantiated ship
//	public bool movementType = false;

	//Network user or other player
	public bool isControllable = false;


	// Use this for initialization
	void Awake() {
		foreach (Transform child in transform) {
			if (child.tag == "MainCamera") {
				cam = child.gameObject;
				camInitPos = cam.transform.localPosition;
			}
			if (child.tag == "PlaceholderShip") {
				placeholderShip = child;
			}
		}
	}
	
	// Movement
	void Update() {
		if (isControllable) {
			Vector3 moveDir = Vector3.zero;
			moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			if (moveDir.magnitude > 0f) {
				ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, Quaternion.LookRotation(moveDir, Vector3.up), shipValues.angularSpeed);
			}
			ship.rigidbody.AddForce(moveDir.magnitude * ship.transform.forward * shipValues.shipSpeed);
			cam.transform.position = camInitPos + ship.transform.position;
		}
	}

	public void changeShip(GameObject newShip) {
		if (ship != null) {
			placeholderShip = ship.transform;
			PhotonNetwork.Destroy(ship);
		}
		GameObject temp = PhotonNetwork.Instantiate(newShip.name, placeholderShip.position, placeholderShip.rotation, 0) as GameObject;
		ship = temp;
		ship.transform.parent = this.transform;
		shipValues = ship.GetComponent<ShipValues>();
	}

	public void changeWeapon(GameObject newWeapon) {
		if (weapon != null) {
			PhotonNetwork.Destroy(weapon);
		}
		GameObject temp = PhotonNetwork.Instantiate(newWeapon.name, shipValues.placeholderWeapon.position, shipValues.placeholderWeapon.rotation, 0) as GameObject;
		weapon = temp;
		weapon.transform.parent = ship.transform;
	}

	public void changeSkill(GameObject newSkill) {
		if (skill != null) {
			PhotonNetwork.Destroy(skill);
		}
		GameObject temp = PhotonNetwork.Instantiate(newSkill.name, shipValues.placeholderSkill.position, shipValues.placeholderSkill.rotation, 0) as GameObject;
		skill = temp;
		skill.transform.parent = ship.transform;
	}
}
