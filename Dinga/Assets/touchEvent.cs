using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class touchEvent : MonoBehaviour {
    public UnityEvent Enter;
    public UnityEvent Exit;
	// Use this for initialization
	void OnPointerEnter (PointerEventData eventData) {
        Enter.Invoke();
	}
    void OnPointerExit(PointerEventData eventData)
    {
        Exit.Invoke();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
