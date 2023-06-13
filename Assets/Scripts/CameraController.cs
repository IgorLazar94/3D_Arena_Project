using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float shakeDuration = 0.1f;
    private float shakeAmount = 0.4f;
    private float decreaseFactor = 1f;
    private float currentShakeDuration = 0f;
    private bool isReadyToShake = false;

    private Vector3 localCameraPos;

    private void LateUpdate()
    {
        if (isReadyToShake)
        {
            Shaking();
        }
    }

    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
        isReadyToShake = true;
        localCameraPos = transform.localPosition;
    }

    private void Shaking()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeAmount;

            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
            isReadyToShake = false;
            transform.localPosition = localCameraPos;
        }
    }
}
