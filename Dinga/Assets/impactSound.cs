using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class impactSound : MonoBehaviour {
   public UnityEvent impactevent;
	// Use this for initialization
	void OnCollisionEnter (Collision col) {
        if (col.collider.transform.root.tag == "Player" && col.collider.GetComponent<Rigidbody>().velocity.magnitude>2) {
            impactevent.Invoke();
            col.collider.transform.root.GetComponent<StairDismount>().impactsound();
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
