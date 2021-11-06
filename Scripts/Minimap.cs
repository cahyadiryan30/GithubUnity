using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; //variable player berbentuk transform

    private void LateUpdate() //fungsi lateupdate
    {
        Vector3 newPosition = player.position; //membuat variable position dan di isi posisi player
        newPosition.y = transform.position.y; //membuat kamera mengikuti player dalam sumbu y
        transform.position = newPosition; //membuat kamera selalu berburu posisi sesuai newPosition

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); //membuat kamera mengikuti rotasi player

    }

}
