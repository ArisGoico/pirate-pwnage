using UnityEngine;
using System.Collections;


public class BulletValues : MonoBehaviour {

	public float speed = 10f;
	public int damage = 1;
	public GameObject target;
	public Vector3 origin;
	private float distance;
	private float startTime;

	// Use this for initialization
	void Start() {
		if (target == null) {
			Debug.LogError("The bullet " + this.transform.name + " has no target defined. Destroying.");
			GameObject.Destroy(this.gameObject);
			return;
		}
		distance = Vector3.Distance(target.transform.position, origin);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update() {
		if (target == null) {
			GameObject.Destroy(this.gameObject);
			return;
		}
		this.transform.rotation = Quaternion.LookRotation(target.transform.position - this.transform.position);
		this.transform.position = Vector3.Lerp(origin, target.transform.position, ((Time.time - startTime) * speed) / distance);
		if (this.transform.position == target.transform.position) {
			ShipValues temp = target.GetComponent<ShipValues>();
			if (temp != null) {
				temp.bulletHit(damage);
			}
			else {
				Debug.LogError("The target " + target.transform.name + " is not a ship (or hasn't values attached).");
			}
			GameObject.Destroy(this.gameObject);
		}
	}
}
