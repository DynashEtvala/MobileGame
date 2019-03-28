using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour {

    public List<GameObject> playerComponents;
    int minval = 1;
    public int maxVal;
    public int hit;
    float timer;
    public float Charge;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer = timer + Time.deltaTime;
		if(timer < Charge && hit != Random.Range(minval,maxVal))
        {
            Debug.Log("Not Firing");
        }
        else if(timer > Charge && hit == Random.Range(minval, maxVal))
        {
            for(int i = 0; i < playerComponents.Count; i++)
            {
                playerComponents[i].transform.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
            timer = 0.0f;
        }
	}
}
