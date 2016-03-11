using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDeisable;

	[SerializeField]
	string remoteLayerName ="RemotePlayerLayer";

	Camera sceneCamera;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) {
			DiableComponents();
			AssignRemotePlayer();
		} else {
			sceneCamera = Camera.main;
			if(sceneCamera != null){
				sceneCamera.gameObject.SetActive(false);
			}
		}
		RegisterPlayer ();
	}
	void RegisterPlayer(){
		string _ID = "Player" + GetComponent<NetworkIdentity> ().netId;
		transform.name = _ID;
	}
	void AssignRemotePlayer(){
		gameObject.layer = LayerMask.NameToLayer (remoteLayerName);
	}

	void DiableComponents(){
		for (int i =0; i < componentsToDeisable.Length; i++) {
			componentsToDeisable [i].enabled = false;
		}
	}
	
	// Update is called once per frame
	void OnDisable() {
		if(sceneCamera != null){
			sceneCamera.gameObject.SetActive(true);
		}
	}

}
