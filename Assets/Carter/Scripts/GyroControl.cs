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
    public GameObject blipPrefab;
    private Plane hitPlane;
    public float distanceToPlane;
    public GameObject eye;
    private Transform eyeTransform;
    public GameObject quad;
    private float distanceToQuad;

    bool test;
    

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
        hitPlane = new Plane(transform.forward, transform.forward * distanceToPlane);
        eyeTransform = eye.GetComponent<Transform>();
	}

    void Update()
    {
        if (gyroEnabled)
        {
            sectorObjectsVis = sectorController.sectorObjects;
            if (!test)
            {
                for (int i = 0; i < sectorObjectsVis.Count;i++)
                {
                    blips.Add(GameObject.Instantiate(blipPrefab));
                    blips[i].transform.SetParent(eyeTransform);
                }
                test = true;
            }

            distanceToQuad = quad.transform.position.z - transform.position.z;

            transform.localRotation = gyro.attitude * rotatation;
            hitPlane.SetNormalAndPosition(transform.forward, transform.forward * distanceToPlane);
            

            Debug.DrawLine(transform.position, hitPlane.ClosestPointOnPlane(transform.position), Color.red, 0.0f, false);

            for (int i = 0; i < sectorObjectsVis.Count; i++)
            {
                //Debug.DrawLine(transform.position, sectorObjectsVis[i].transform.position, Color.red, 0.0f, false);

                float distanceToObject;
                Ray ray = new Ray(transform.position, sectorObjectsVis[i].transform.position);
                hitPlane.Raycast(ray, out distanceToObject);
                Vector3 v = ray.GetPoint(distanceToObject);

                eyeTransform.rotation = transform.rotation;
                blips[i].transform.position = new Vector3(v.x, v.y, .5f);
                eyeTransform.rotation = new Quaternion(0, 0, 0, 0);
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
