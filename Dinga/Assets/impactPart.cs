using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class impactPart : MonoBehaviour {
    public UnityEvent impact;
    public float impactForce;
    // Use this for initialization
    void Start () {
		
	}

    IEnumerator destroyOnTime(GameObject obj) {
        yield return new WaitForSeconds(4);
        Destroy(obj);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.transform.root.tag == "Player" && col.collider.GetComponent<Rigidbody>().velocity.magnitude > impactForce)
        {
            col.collider.transform.root.GetComponent<StairDismount>().impactsound();
            impact.Invoke();
            transform.gameObject.layer = 10;
            Destroy(GetComponent<FixedJoint>());
            GetComponent<Rigidbody>().AddExplosionForce(42f, col.contacts[0].point, 3f);
            StartCoroutine(destroyOnTime(this.gameObject));
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
