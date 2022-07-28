using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private CharacterController player;

    [Header("Camera Setting")]
    [SerializeField]
    private Transform playerCamera;
    [SerializeField]
    private Vector3 cameraOffset;
    [SerializeField]
    private float mouseSensetive;

    [Header("other")]
    [SerializeField]
    private float gravitation = 9.8f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float heightJump;
    private float speedFall;

    private float mouseX;
    private float mouseY;

    public bool Grounded { get; private set; }
    public bool jump;
    public bool IsWalk
    {
        get
        {
            if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0)) return true;
            else return false;
        }
    }
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Grounded = player.isGrounded;

        speedFall += gravitation * Time.deltaTime;
        var along= Input.GetAxis("Vertical");
        var across= Input.GetAxis("Horizontal");
        var velocity = (transform.forward * along) + (transform.right * across) + -(transform.up * speedFall);
        player.Move(velocity * Time.deltaTime * speed);
        if (player.isGrounded)
        {
            speedFall = -0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedFall = -heightJump;
            jump = true;
        }
    }
    private void LateUpdate()
    {
        CameraRotate();
    }
    private void CameraRotate()
    {
        playerCamera.position = transform.position;

        var offset = cameraOffset;
        Ray ray = new Ray(playerCamera.position, -playerCamera.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < cameraOffset.z)
            {
                offset.z = hit.distance;
            }
        }
        mouseX += mouseSensetive * Input.GetAxis("Mouse X");
        mouseY -= mouseSensetive * Input.GetAxis("Mouse Y");

        var camXClamp = Mathf.Clamp(mouseY, -10f ,40f);

        playerCamera.rotation = Quaternion.Euler(camXClamp, mouseX, playerCamera.rotation.eulerAngles.z);

        if (IsWalk)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, mouseX, transform.rotation.z);
        }
        playerCamera.position += (playerCamera.right * offset.x) + (playerCamera.up * offset.y) + (-playerCamera.forward * offset.z);
    }
}

