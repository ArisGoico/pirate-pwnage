using UnityEngine;
using System.Collections;


public class NetworkMatchmaker : MonoBehaviour {

	public Transform[]  playerPosition;
	private int thisPlayer = 0;


	// Use this for initialization
	void Start() {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom() {
		thisPlayer = PhotonNetwork.playerList.Length - 1;
		GameObject ship = PhotonNetwork.Instantiate("Simple Player Photon", playerPosition[thisPlayer].position, playerPosition[thisPlayer].rotation, 0);
		ship.GetComponent<Movement>().isControllable = true;
		ship.GetComponent<PlayerGUI>().isControllable = true;
		ship.GetComponentInChildren<Camera>().enabled = true;
		ship.GetComponentInChildren<AudioListener>().enabled = true;
	}
	
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}
