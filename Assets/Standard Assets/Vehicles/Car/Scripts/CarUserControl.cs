using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
		private float timeLimit = 20.0f;
		public GameObject sphere;
		private int health = 100;
		public GameObject explosion;
		private float nextfire;
		public GameObject shot;
		public Transform shotSpan;
		public float fireRate;
		private Boolean fire = false;
		private int NoOfFire = 0;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

		private void Update(){
			if (Input.GetButton("Fire1") && Time.time > nextfire && NoOfFire>0 && fire == true) {
				nextfire= Time.time + fireRate;
				Instantiate (shot, shotSpan.position, shotSpan.rotation);
				Instantiate (explosion, transform.position, transform.rotation);
				NoOfFire--;
			}
			if (fire == true && NoOfFire == 0) {
				fire = false;
				NoOfFire = 10;
			}
			if (timeLimit > 1) {
				// Decrease timeLimit.
				timeLimit -= Time.deltaTime;
				// translate backward.
				transform.Translate (Vector3.back * Time.deltaTime, Space.World);
			} else {
				sphere.SetActive(false);
			}
		}

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
		void OnTriggerEnter(Collider other){
			if (other.gameObject.CompareTag ("Pick Up")) {
				other.gameObject.SetActive (false);
				NoOfFire=10;
				fire = true;
			}
			if (other.gameObject.CompareTag ("Defense")) {
				other.gameObject.SetActive (false);
				sphere.SetActive(true);
			}
		}
    }
}
