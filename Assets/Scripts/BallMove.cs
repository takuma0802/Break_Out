using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	float speed = 25.0f;

	void  Update (){
		if (Input.GetButtonUp("Jump") && GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)){
			GetComponent<Rigidbody>().AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
		}
	}
	
	void OnCollisionEnter (){
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = rigidbody.velocity.normalized * 25;
	}
}
