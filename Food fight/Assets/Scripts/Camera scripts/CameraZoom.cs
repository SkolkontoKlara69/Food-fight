using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 8f;
    private float maxZoom = 12f;
    private float velocityScroll = 0f;
    private float smoothTimeScroll = 0.25f;
    private float scroll;

    public Transform playerTransform;

    [SerializeField] private Camera cam;

    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Axis limitation")]
    public Vector3 xLimit; // x axis limit
    public Vector3 yLimit; // y axis limit

    private void Start()
    {
        cam = Camera.main;
        zoom = cam.orthographicSize;
    }

    void Update()
    {
        if(playerTransform.position.y >= 4.5 && cam.orthographicSize <= 12)
        {
            scroll = -1;
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocityScroll, smoothTime);
        }
        else
        {
            scroll = +1;
            zoom -= scroll * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocityScroll, smoothTime);
        }
   
    }
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }    

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
