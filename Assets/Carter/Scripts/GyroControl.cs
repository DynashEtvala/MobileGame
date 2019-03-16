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
    float angle = 10f;
    [SerializeField]
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
                    t.GetComponentInParent<Renderer>().material.color = new Color(255, 255, 255, 255);
                }
                else
                {
                    t.GetComponentInParent<Renderer>().material.color = new Color(0, 0, 0, 0);
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
