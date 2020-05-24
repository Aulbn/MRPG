using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Camera cam;
    public static Camera Cam { get { return Instance.cam; } }

    [Header("Positioning")]
    public Vector3 rotation;
    public float distance = 5f;
    public float smooth = .3f;



    private Vector3 velocity = Vector3.zero;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(rotation);
        cam.transform.localPosition = Vector3.back * distance;
        transform.position = Vector3.SmoothDamp(transform.position, Player.Transform.position, ref velocity, smooth);
    }
}
