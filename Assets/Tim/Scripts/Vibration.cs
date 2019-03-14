using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {

    private int randVal;
    void Start () {
	}

    // Update is called once per frame
    public void OnClick()
    {
      Handheld.Vibrate();
        
    }
    public void OnHit()
    {
        randVal = Random.Range(1, 5);
        if(randVal == 3)
        {
            Handheld.Vibrate();
        }
    }
}
