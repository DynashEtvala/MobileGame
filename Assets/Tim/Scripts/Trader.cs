using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trader : MonoBehaviour {

    public List<GameObject> Objs = new List<GameObject>();
    public string weaponName;
    public int currency;
    public int weaponCost;
    private List<Button> button = new List<Button>();
    // Use this for initialization
    void Start()
    {
        button[0].GetComponent<Text>().text = "Shop\n";
        for (int i = 0; i < Random.Range(2, 5); i++)
        {
            switch (i)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
