using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private Quaternion startRotation;
    private Quaternion? targetRotation;
    private float _degVelosity;
    private bool isShaking;
    private Coroutine _shakeCoroutine;
    public void ShakeRotateCamera(Vector2 direction, float angleDeg, float degVelosity)
    {
        if(isShaking)
        {
            return;
        }
        ShakeRotateCameraInternal(direction, angleDeg, degVelosity);
    }
    public void ShakeCamera(float duration, float maxAngle, float degVelocity)
    {
        if(_shakeCoroutine != null)
        {
            StopCoroutine(_shakeCoroutine);
            isShaking = false;
            _shakeCoroutine = StartCoroutine(VibrateCameraCor(duration, maxAngle, degVelocity));
        }
     }
    private void Start()
    {
        startRotation = transform.localRotation;
    }
    private void Update()
    {
        Quaternion target = targetRotation == null ? startRotation : targetRotation.Value;
        if (target == transform.localRotation) 
        {
            return;
        }

        float t = (Time.deltaTime * _degVelosity) / Quaternion.Angle(transform.localRotation, target);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, t);
        if(transform.localRotation == target)
        {
            targetRotation = null;
        }
     }
    private IEnumerator VibrateCameraCor(float duration, float MaxAngle, float degVelocity)
    {
        isShaking = true;
        float elapsed = 0;
        float timePassed = Time.realtimeSinceStartup;
        while(elapsed < duration)
        {
            float currentTime = Time.realtimeSinceStartup;
            elapsed += currentTime - timePassed;
            timePassed = currentTime;

            ShakeRotateCameraInternal(Random.insideUnitCircle, Random.Range(0, MaxAngle), degVelocity);
            
            yield return new WaitForSeconds(0.05f);
        }
        isShaking = false;  

    }
    private void ShakeRotateCameraInternal(Vector2 direction, float angleDeg, float degVelosity)
    {
        _degVelosity = degVelosity;
        direction = direction.normalized;
        direction *= Mathf.Tan(angleDeg * Mathf.Deg2Rad);
        Vector3 resDirection = ((Vector3)direction + transform.forward).normalized;
        targetRotation = Quaternion.FromToRotation(transform.forward, resDirection);
    }
}
