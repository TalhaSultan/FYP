using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {


//	public GameObject sphere;
//	public GameObject shot;
//	public Transform shotSpan;
//	private int health = 100;
//	public Transform PositionOfRobotCar;
//	public Transform PositionOfUserCar;
//	public GameObject explosion;
//	private bool fire = false;
//	private int NoOfFire = 0;

	private const string PLAYER_TAG = "Player";

	public PlayerWeapon weapon;

	[SerializeField]
	private LayerMask mask;

	[SerializeField]
	private Camera cam;
	// Use this for initialization
	void Start () {
		if (cam == null) {
			Debug.Log("Player Shoot: No camera Referance!!");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
//	void Update () {
//		CmdUpdate ();
//	}
	[Client]
	void Shoot(){
		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position,cam.transform.transform.forward,out _hit, weapon.range, mask)) {
			//we hit something
			Debug.Log("We hit: " + _hit.collider.name);
		}
		if (_hit.collider.tag == PLAYER_TAG) {
			CmdPlayerShoot(_hit.collider.name);
		}
	}

	[Command]
	void CmdPlayerShoot(string _ID){
		Debug.Log (_ID + "has been Shot.");
		//GameObject.Find (_ID);
	}
	
//	void OnTriggerEnter(Collider other){
//		CmdOnTriggerEnter (other);
//	}

//	[Command]
//	void CmdUpdate(){
//		if (Input.GetButtonDown ("Fire1")) {
//			Shoot();
//		}
//		if(fire == true && (PositionOfRobotCar.position.z % transform.position.z) <= 2){
//			Instantiate (shot, shotSpan.position, shotSpan.rotation);
//			Instantiate (explosion, transform.position, transform.rotation);
//			NoOfFire--;
//		}
//		if (fire == true && NoOfFire == 0) {
//			fire = false;
//			NoOfFire = 10;
//		}
//	}
//
//	[Command]
//	void CmdOnTriggerEnter(Collider other){
//		if (other.tag == "Boundary") {
//			return;
//		}
//		if (other.tag == "Untagged") {
//			Instantiate (explosion, transform.position, transform.rotation);
//			Destroy (other.gameObject);
//			if (health <= 0) {
//				Destroy (gameObject);
//			} else {
//				health -= 20;
//				gameObject.transform.rotation = Quaternion.Euler (0, Random.Range (0, 180), Random.Range (0, 180));
//			}
//		}
//		if(other.tag == "Defense" || other.tag == "Pick Up"){
//			if(other.tag == "Pick Up"){
//				fire = true;
//				NoOfFire=10;
//			}
//			if(other.tag == "Defense"){
//				//other.gameObject.SetActive (false);
//				sphere.SetActive(true);
//			}
//			other.gameObject.SetActive (false);
			
//		}
//	}
}
