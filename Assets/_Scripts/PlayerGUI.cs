﻿using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	//Ships
	public GameObject[] ships;
	private int actualShip;

	//Weapons
	public GameObject[] weapons;
	private int actualWeapon;

	//Skills
	public GameObject[] skills;
	private int actualSkill;

	public Texture2D okButton;
	
	public int gold = 0;

	private Movement shipMovement;

	private bool inShipyard = false;

	// Use this for initialization
	void Awake() {
		if (okButton == null) {
			Debug.LogError ("Texture2D okButton is not initialized. Preventing errors, PlayerGUI script is disabled.");
			this.enabled = false;
			return;
		}
		if (ships == null) {
			Debug.LogError ("Ships are not initialized. Preventing errors, PlayerGUI script is disabled.");
			this.enabled = false;
			return;
		}
		if (weapons == null) {
			Debug.LogError ("Weapons are not initialized. Preventing errors, PlayerGUI script is disabled.");
			this.enabled = false;
			return;
		}
//		if (skills == null) {
//			Debug.LogError ("Skills are not initialized. Preventing errors, PlayerGUI script is disabled.");
//			this.enabled = false;
//		}
		shipMovement = this.gameObject.GetComponent<Movement>();
		if (shipMovement == null) {
			Debug.LogError ("Ship Movement script is not initialized. Preventing errors, PlayerGUI script is disabled.");
			this.enabled = false;
			return;
		}
		shipMovement.changeShip(ships[0]);
		actualShip = 0;
		shipMovement.changeWeapon(weapons[0]);
		actualWeapon = 0;
//		shipMovement.changeSkill(skills[0]);
		actualSkill = 0;
	}

	void OnGUI() {
		if (inShipyard) {
			GUI.Label(new Rect(5f, 5f, 20f, 20f), okButton);
		}
		GUI.Label(new Rect(Screen.width - 40f, 5f, 35f, 35f), "Gold:\n" + gold);
	}
	
	// Update is called once per frame
	void Update () {
		if (inShipyard) {
			changeControls();
		}
	}

	public void setShipyard(bool value) {
		inShipyard = value;
	}

	public void addGold(int value) {
		gold += value;
	}

	private void changeControls() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			int temp = actualShip + 1;
			if (temp >= ships.Length)
				temp = 0;
			shipMovement.changeShip(ships[temp]);
			actualShip = temp;
			shipMovement.changeWeapon(weapons[actualWeapon]);
//			shipMovement.changeSkill(skills[actualSkill]);
			Debug.Log("Cambiado barco.");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			int temp = actualWeapon + 1;
			if (temp >= weapons.Length)
				temp = 0;
			shipMovement.changeWeapon(weapons[temp]);
			actualWeapon = temp;
			Debug.Log("Cambiada arma.");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			int temp = actualSkill + 1;
			if (temp >= skills.Length)
				temp = 0;
//			shipMovement.changeSkill(skills[temp]);
			actualSkill = temp;
			Debug.Log("Cambiada skill.");
		}
	}
}
