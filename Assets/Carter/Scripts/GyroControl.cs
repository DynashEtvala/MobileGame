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
    private GameObject cameraContainer;

    //Game object method
    private GameObject[] detectableObjects;
    public List<Transform> detectableObjectsTransforms;

    //Data oriented method
    private GameObject objectManager;
    private scr_SectorController sectorController;
    private cl_Sector currSector;
    private List<cl_SectorObject> sectorObjects;
    

	void Start () {
        cameraContainer = new GameObject("CameraContainer");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
        //detectableObjects = GameObject.FindGameObjectsWithTag("detectableObject");
        //foreach(GameObject obj in detectableObjects)
        //{
        //    detectableObjectsTransforms.Add(obj.transform);
        //}
        objectManager = GameObject.FindGameObjectWithTag("GameManager");
        sectorController = objectManager.GetComponent<scr_SectorController>();
        currSector = sectorController.currSector;
        sectorObjects = currSector.sectorObjects;
        foreach(cl_SectorObject obj in sectorObjects)
        {
            Debug.Log(obj.ToString());
            obj.position.y = -10;
            Debug.Log(obj.position);
        }
        sectorObjects[0].position.y = 10;
	}

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotatation;
            /*foreach (Transform t in detectableObjectsTransforms)
            {
                float currAngle = Vector3.Angle(transform.forward, t.position - transform.position);
                if (currAngle < angle)
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                else if (currAngle < angle + 5.0f)
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.8f);
                }
                else if (currAngle < angle + 7.0f)
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                }
                else if (currAngle < angle + 10.0f)
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
                }
                else
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
                }
            }*/
            foreach (cl_SectorObject obj in sectorObjects)
            {
                float relativeCurrentAngle = Vector3.Angle(transform.forward, obj.position);
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
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotatation = new Quaternion(0f, 0f, 1f, 0f);
            return true;
        }
        return false;
    }
}
