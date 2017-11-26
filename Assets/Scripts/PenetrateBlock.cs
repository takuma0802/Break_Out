using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateBlock : MonoBehaviour {

	void  OnTriggerEnter (){
		Destroy(gameObject);
	}
}
