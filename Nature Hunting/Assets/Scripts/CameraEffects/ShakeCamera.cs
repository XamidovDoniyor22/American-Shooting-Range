using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private Transform camTransform;
     private float shakeDur = 0.08f, shakeAmount = 0.008f, decreaseFactor = 0.3f;

    private Vector2 originPos;

    private void Start()
    {
        camTransform = GetComponent<Transform>();
        originPos = camTransform.localPosition;
    }
    private void Update()
    {
        if(shakeDur > 0)
        {
            camTransform.localPosition = originPos + (Random.insideUnitCircle * shakeAmount);
            shakeDur -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDur = 0;
            camTransform.localPosition = originPos;
        }
    }
}
