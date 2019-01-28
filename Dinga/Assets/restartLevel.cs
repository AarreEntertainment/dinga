using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class restartLevel : MonoBehaviour {
    public UnityEvent transition;

    IEnumerator flush() {

        transition.Invoke();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player") {
            other.transform.root.GetComponent<StairDismount>().enabled = false;
            other.transform.root.GetComponent<movement>().enabled = false;
            StartCoroutine(flush());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
