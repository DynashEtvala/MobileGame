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

    //Game object method
    private GameObject[] detectableObjects;
    public List<Transform> detectableObjectsTransforms;

    //Data oriented method
    private GameObject objectManager;
    private cl_SectorObject[] sectorObjects;
    

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

        sectorObjects = GetComponents<cl_SectorObject>();
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
                float currAngle = Vector3.Angle(transform.forward, obj. - transform.position);
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
