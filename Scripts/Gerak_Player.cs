using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak_Player : MonoBehaviour
{
     //Movement 
    public float kecepatan = 4f;
    public float x;
    public float z;

    //Lompat
    [SerializeField] private float speed_jump = 2f;

    // Gravitasi
    private float gravitasi = 20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGround;
    Vector3 velocity;

    //Camera 
    private float FOV = 60f;

    //referensi
    public CharacterController controller;
    // Start is called before the first frame update

    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        gravity();
        lompat();
    }

    private void movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            kecepatan = 7f;
            Camera.main.fieldOfView = 50f;
        }
        else
        {
            kecepatan = 4f;
            Camera.main.fieldOfView =40f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * kecepatan * Time.deltaTime);
}
    private void gravity()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void lompat()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(speed_jump * 2f * gravitasi);
        }
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
