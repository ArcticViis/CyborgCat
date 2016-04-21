using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
		public Vector3 eulerAngleVelocity;
		public Rigidbody rb;
		void Start() {
			rb = GetComponent<Rigidbody>();
		}
		void FixedUpdate() {
			Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
			rb.MoveRotation(rb.rotation * deltaRotation);
		}
	}
