using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject sphere;
	public GameObject shot;
	public Transform shotSpan;
	private int health = 100;
	public Transform PositionOfRobotCar;
	public Transform PositionOfUserCar;
	public GameObject explosion;
	private bool fire = false;
	private int NoOfFire = 0;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "Untagged") {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			if (health <= 0) {
				Destroy (gameObject);
			} else {
				health -= 20;
				gameObject.transform.rotation = Quaternion.Euler (0, Random.Range (0, 180), Random.Range (0, 180));
			}
		}
		if(other.tag == "Defense" || other.tag == "Pick Up"){
			if(other.tag == "Pick Up"){
				fire = true;
				NoOfFire=10;
			}
			if(other.tag == "Defense"){
				other.gameObject.SetActive (false);
				sphere.SetActive(true);
			}
			other.gameObject.SetActive (false);

		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fire == true && (PositionOfRobotCar.position.z % transform.position.z) <= 2){
		Instantiate (shot, shotSpan.position, shotSpan.rotation);
		Instantiate (explosion, transform.position, transform.rotation);
			NoOfFire--;
		}
		if (fire == true && NoOfFire == 0) {
			fire = false;
			NoOfFire = 10;
		}
	}
}
