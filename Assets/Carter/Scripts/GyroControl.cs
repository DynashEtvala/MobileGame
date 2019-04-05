using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    [SerializeField]
    private bool gyroEnabled;
    private bool firstRun;
    public float distanceToPlane;
    private float distanceToQuad;


    private GameObject gyroContainer;
    private GameObject objectManager;
    public GameObject quad;
    public GameObject eye;
    public GameObject blipPrefab;
    public GameObject buttonPrefab;
    public GameObject dispScrnPrefab;
    private GameObject dispScrn;
    private TMPro.TextMeshProUGUI dispScrnInfo;
    private List<GameObject> sectorObjectsVis;
    public List<GameObject> blips;

    private Transform eyeTransform;

    private Camera cam;

    private Gyroscope gyro;

    private Quaternion rotatation;

    private Plane hitPlane;

    private scr_SectorController sectorController;
    private cl_Sector currSector;
    private List<cl_SectorObject> sectorObjects;

    private Dictionary<GameObject, cl_SectorObject> blipToObjDict = new Dictionary<GameObject, cl_SectorObject>();

	void Start () {
        gyroContainer = new GameObject("Gyro Container");
        gyroContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        gyroContainer.transform.position = transform.position;
        rotatation = new Quaternion(0f, 0f, 1f, 0f);
        transform.SetParent(gyroContainer.transform);
        gyroEnabled = EnableGyro();
        objectManager = GameObject.FindGameObjectWithTag("GameManager");
        sectorController = objectManager.GetComponent<scr_SectorController>();
        currSector = sectorController.currSector;
        sectorObjects = currSector.sectorObjects;
        sectorObjectsVis = sectorController.sectorObjects;
        hitPlane = new Plane(transform.forward, transform.forward * distanceToPlane);
        eyeTransform = eye.GetComponent<Transform>();
        cam = Camera.FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (gyroEnabled)
        {
            sectorObjectsVis = sectorController.sectorObjects;
            if (!firstRun)
            {
                for (int i = 0; i < sectorObjectsVis.Count;i++)
                {
                    blips.Add(GameObject.Instantiate(blipPrefab));
                    blipToObjDict.Add(blips[i], sectorObjects[i]);
                }
                firstRun = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 touchPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
                Vector3 touchPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
                Vector3 touchPosF = cam.ScreenToWorldPoint(touchPosFar);
                Vector3 touchPosN = cam.ScreenToWorldPoint(touchPosNear);
                RaycastHit rayHit;

                if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out rayHit))
                {
                    if (!blipToObjDict.ContainsKey(rayHit.transform.gameObject))
                    {
                        Debug.Log("Not Dict");
                    }
                    else
                    {
                        cl_SectorObject temp = blipToObjDict[rayHit.transform.gameObject];
                        
                        if(dispScrn == null)
                        {
                            dispScrn = GameObject.Instantiate(dispScrnPrefab);
                            dispScrnInfo = dispScrn.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                            dispScrnInfo.text = "Hi";
                        }
                        else
                        {
                            dispScrn.SetActive(true);
                        }


                            
                        for (int i = 0; i < temp.tags.Count; i++)
                        {
                            Debug.Log(temp.tags[i]);
                        }
                    }
                }
            }

            distanceToQuad = quad.transform.position.z - transform.position.z;
            transform.localRotation = gyro.attitude * rotatation;
            hitPlane.SetNormalAndPosition(transform.forward, transform.forward * distanceToPlane);

            Debug.DrawLine(transform.position, hitPlane.ClosestPointOnPlane(transform.position), Color.red, 0.0f, false);

            for (int i = 0; i < sectorObjectsVis.Count; i++)
            {
                float distanceToObject;
                Ray ray = new Ray(transform.position, sectorObjectsVis[i].transform.position);

                if (hitPlane.Raycast(ray, out distanceToObject))
                {
                    Vector3 v = ray.GetPoint(distanceToObject);
                    eyeTransform.rotation = transform.rotation;
                    blips[i].transform.position = v;
                    blips[i].transform.SetParent(eyeTransform, false);
                    eyeTransform.rotation = new Quaternion(0, 0, 0, 0);
                    blips[i].transform.SetParent(eyeTransform, true);
                    Vector3 blipV = blips[i].transform.position;
                    if (blipV.x < -0.5f ||
                       blipV.x > 0.5f  ||
                       blipV.y < -0.5f ||
                       blipV.y > 0.5f)
                    {
                        blips[i].GetComponent<Renderer>().enabled = false;
                    }
                    else
                    {
                        blips[i].GetComponent<Renderer>().enabled = true;
                    }
                }
                else
                {
                    blips[i].GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }
}