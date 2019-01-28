using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControls : MonoBehaviour {
    public GameObject touchCTRLS;
    void getJumpTouch() { }
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && !touchCTRLS.activeSelf) {
            touchCTRLS.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().touchControlsEnabled=true;

        }
	}
}
