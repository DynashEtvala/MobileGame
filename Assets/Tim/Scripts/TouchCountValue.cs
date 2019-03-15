using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchCountValue : MonoBehaviour {
    public Text txt;
    Touch touch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            txt.text = "Touch" + Input.touchCount + "\n" + touch.position;
        }
    }
}
