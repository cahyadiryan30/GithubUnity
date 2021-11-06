using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animasi : MonoBehaviour
{
    //variable
    private float kecepatan_player;
    public float nilai_x;
    public float nilai_z;
    private bool status_ground;

    private bool stat_jump;
    private bool isCrouched;

    //referensi
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        nilai_x = player.GetComponent<Gerak_Player>().x;
        nilai_z = player.GetComponent<Gerak_Player>().z;
        status_ground = player.GetComponent<Gerak_Player>().isGround;
        kecepatan_player = player.GetComponent<Gerak_Player>().kecepatan;
        stat_jump = Input.GetButtonDown("Jump");
        isCrouched = Input.GetKeyDown(KeyCode.C);

        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("isGrounded", status_ground);
        anim.SetFloat("speed", kecepatan_player);
        anim.SetBool("status_jump", stat_jump);
        anim.SetBool("status_crouch", isCrouched);
       
    }
}
