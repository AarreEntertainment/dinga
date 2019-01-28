using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class breakdown : MonoBehaviour {
    public UnityEvent impact;
    public float impactForce;
	    // Use this for initialization
	    void Start () {
		
	    }
    IEnumerator destroyOnTime(GameObject obj)
    {
        yield return new WaitForSeconds(4);
        Destroy(obj);
    }
    void OnCollisionEnter(Collision col) {
        if (col.collider.transform.root.tag == "Player" && col.collider.GetComponent<Rigidbody>().velocity.magnitude > impactForce) {
            col.collider.transform.root.GetComponent<StairDismount>().impactsound();
            impact.Invoke();
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            foreach (Transform child in transform) {
                if (child.GetComponent<MeshCollider>() != null)
                {
                    Destroy(child.GetComponent<FixedJoint>());
                    child.GetComponent<Rigidbody>().AddExplosionForce(42f, col.contacts[0].point, 3f);
                    child.GetComponent<MeshCollider>().enabled = true;
                    StartCoroutine(destroyOnTime(child.gameObject));
                }
                else if(child.GetComponent<AudioSource>() == null)
                    Destroy(child.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
