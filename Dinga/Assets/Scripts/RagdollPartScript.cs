using UnityEngine;
using System.Collections;

public class RagdollPartScript : MonoBehaviour {
	//Declare a reference to the main script (of type StairDismount).
	//This will be set by the code that adds this script to all ragdoll parts
	public StairDismount mainScript;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision collision)
	{
		//Increase score if this ragdoll part collides with something else
		//than another ragdoll part with sufficient velocity. 
		//If the colliding object is another ragdoll part, it will have the same root, hence the inequality check.
		if (transform.root != collision.transform.root)
		{
            //Check that we are colliding with sufficient velocity
            if (collision.relativeVelocity.magnitude > 4.0f)
            {
                //compute score
            }
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
