using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    [SerializeField]
    private bool gyroEnabled;
    private Gyroscope gyro;
    [SerializeField]
    private Quaternion rotatation;
    [SerializeField]
    float angle;
    [SerializeField]
    private GameObject gyroContainer;

    //Data oriented method
    private GameObject objectManager;
    private scr_SectorController sectorController;
    private cl_Sector currSector;
    private List<cl_SectorObject> sectorObjects;
    private List<GameObject> sectorObjectsVis;
    public List<GameObject> blips;
    private Plane hitPlane;

    bool test;
    float testF;
    

	void Start () {
        gyroContainer = new GameObject("Gyro Container");
        gyroContainer.transform.position = transform.position;
        transform.SetParent(gyroContainer.transform);
        gyroEnabled = EnableGyro();
        objectManager = GameObject.FindGameObjectWithTag("GameManager");
        sectorController = objectManager.GetComponent<scr_SectorController>();
        currSector = sectorController.currSector;
        sectorObjects = currSector.sectorObjects;
        sectorObjectsVis = sectorController.sectorObjects;
        hitPlane = new Plane(transform.forward, transform.forward * 1f);
	}

    void Update()
    {
        if (gyroEnabled)
        {
            sectorObjectsVis = sectorController.sectorObjects;
            if (!test)
            {
                foreach (GameObject obj in sectorObjectsVis)
                {
                    blips.Add(new GameObject("Blip"));
                }
                test = true;
            }

            

            transform.localRotation = gyro.attitude * rotatation;
            hitPlane.SetNormalAndPosition(transform.forward, transform.forward * 1f);


            Debug.DrawLine(transform.position, hitPlane.ClosestPointOnPlane(transform.position), Color.magenta, 0.0f, false);

            for (int i = 0; i < sectorObjectsVis.Count; i++)
            {
                Debug.DrawLine(transform.position, sectorObjectsVis[i].transform.position, Color.red, 0.0f, false);

                Ray ray = new Ray(transform.position, sectorObjectsVis[i].transform.position);
                hitPlane.Raycast(ray, out testF);
                Debug.Log(testF);

                blips[i].transform.position = new Vector3(sectorObjectsVis[i].transform.position.x, sectorObjectsVis[i].transform.position.y, sectorObjectsVis[i].transform.position.z);

                float relativeCurrentAngle = Vector3.Angle(transform.forward, sectorObjectsVis[i].transform.position);
                if(relativeCurrentAngle <= angle)
                {
                    //Lock on
                    Debug.Log("Lock On");
                }
                else if(relativeCurrentAngle <= angle + angle * 0.10f)
                {
                    //75% Lock on
                    Debug.Log("75% Lock On");
                }
                else if(relativeCurrentAngle <= angle + angle * 0.50f)
                {
                    //50% Lock on
                    Debug.Log("50% Lock On");
                }
                else if(relativeCurrentAngle <= angle + angle * 0.75f)
                {
                    //25% Lock on
                    Debug.Log("25% Lock On");
                }
                else if(relativeCurrentAngle <= angle + angle)
                {
                    //10% Lock on
                    Debug.Log("10% Lock On");
                }
                else
                {
                    //No Lock
                }
            }

        }
    }

    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotatation = new Quaternion(0f, 0f, 1f, 0f);
            return true;
        }
        return false;
    }
}
