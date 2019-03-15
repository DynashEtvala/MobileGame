using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rotatation;
    float angle = 10f;
    private GameObject cameraContainer;


    private GameObject[] detectableObjects;
    public List<Transform> detectableObjectsTransforms;

	void Start () {
        cameraContainer = new GameObject("CameraContainer");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        gyroEnabled = EnableGyro();
        detectableObjects = GameObject.FindGameObjectsWithTag("detectableObject");
        foreach(GameObject obj in detectableObjects)
        {
            detectableObjectsTransforms.Add(obj.transform);
        }
	}

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotatation;
            foreach (Transform t in detectableObjectsTransforms)
            {
                if (Vector3.Angle(transform.forward, t.position - transform.position) < angle)
                {
                    //Debug.Log(t);
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
