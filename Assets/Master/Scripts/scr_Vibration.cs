using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {
    public int minval;
    public int maxval;
    public int hitval;
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
        randVal = Random.Range(minval, maxval);
        if(randVal == hitval)
        {
            Handheld.Vibrate();
        }
    }
}
