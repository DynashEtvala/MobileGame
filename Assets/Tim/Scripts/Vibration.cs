using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {

    private int randVal;
    public int maxval;
    public int minval;
    public int hitval;
    void Start () {
	}

    // Update is called once per frame
    public void OnClick()
    {
      Handheld.Vibrate();
        
    }
    public void OnHit()
    {
        randVal = Random.Range(minval,maxval );
        if(randVal == hitval)
        {
            Handheld.Vibrate();
        }
    }
}
