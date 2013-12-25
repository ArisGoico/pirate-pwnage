using UnityEngine;
using System.Collections;


public class ShipWeapon : MonoBehaviour {

	public GameObject bullet;
	public int damagePerHit = 1;
	public float hitsPerSecond = 1f;
	private float lastShot = 0f;
	private bool shooting = false;

	private GameObject[] targets;
	private int targetNum = 0;

	private Transform placeHolderBullet;

	// Use this for initialization
	void Start() {
		targets = new GameObject[10];
		if (bullet == null) {
			Debug.LogError("The ship " + this.transform.parent.name + " has no bullets defined. Deactivating weapons.");
			this.enabled = false;
		}
		foreach (Transform child in transform) {
			if (child.tag == "PlaceholderBullet") {
				placeHolderBullet = child;
			}
		}
	}
	
	// Update is called once per frame
	void Update() {
		if (targets[0] != null) {
			Vector3 temp = targets[0].transform.position - this.transform.position;
			this.transform.rotation = Quaternion.LookRotation(new Vector3(temp.x, 0f, temp.z));
			if (!shooting) {
				InvokeRepeating("shootBullet", 0.1f, 1f / hitsPerSecond);
				shooting = true;
			}
		}
		else {
			this.transform.rotation = Quaternion.LookRotation(this.transform.parent.forward);
			CancelInvoke("shootBullet");
			shooting = false;
		}
	}

	public bool addTarget(GameObject newTarget) {
		if (newTarget.tag == "Ship" && targetNum < targets.Length && !checkArray(newTarget, targets, targetNum)) {
			targets[targetNum] = newTarget;
			targetNum ++;
			return true;
		}		
		return false;
	}

	public bool delTarget(GameObject newTarget) {
		bool found = false;
		int tempIndex = -1;
		for (int i = 0; i < targets.Length; i++) {
			if (targets[i] == newTarget) {
				found = true;
				targets[i] = null;
				tempIndex = i;
			}
		}
		if (found) {
			for (int i = tempIndex; i < targetNum - 1; i++) {
				targets[i] = targets[i + 1];
			}
			targets[targetNum - 1] = null;
			targetNum--;
		}
		return found;
	}

	private bool checkArray(GameObject obj, GameObject[] array, int arrayIndex) {
		for (int i = 0; i < arrayIndex; i++) {
			if (array[i] == obj) {
				return true;
			}
		}
		return false;
	}

	private void shootBullet() {
		Instantiate(bullet, placeHolderBullet.position, placeHolderBullet.rotation);
	}
}
