using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyTurns : MonoBehaviour
{
    [Header("For Shoot Rotation")]
    private float sensVert = 0.4f;
    private float sensHor = 0.4f;

    [SerializeField] private float minVert = -45;
    [SerializeField] private float maxVert = 45;

    [SerializeField]
    private float offset;

    private float rotationY = 0;
    private Vector3 rotation = Vector3.zero;

    [SerializeField]
    private Joystick joystick;

    private void Update()
    {
        ////y
        //rotationY -= Input.GetAxis("Mouse Y") * sensVert;
        //rotationY = Mathf.Clamp(rotationY, minVert, maxVert);
        //transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y, rotation.z);
        ////x
        //transform.Rotate(0, Input.GetAxis("Mouse X") * sensHor, 0);

        Smthg();
    }
    private void Smthg()
    {
        //y
        rotationY -= joystick.Vertical * sensVert;
        rotationY = Mathf.Clamp(rotationY, minVert, maxVert);
        transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y, rotation.z);
        //x
        transform.Rotate(0, joystick.Horizontal * sensHor, 0);
    }
    private void Rotation()
    {
        float rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);
    }

}
