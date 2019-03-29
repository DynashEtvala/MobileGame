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
        objectManager = GameObject.FindGameObjectWithTag("GameManager");
        sectorController = objectManager.GetComponent<scr_SectorController>();
        currSector = sectorController.currSector;
        sectorObjects = currSector.sectorObjects;
	}

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotatation;
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
