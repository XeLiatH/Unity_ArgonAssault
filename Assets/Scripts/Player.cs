using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 6.0f;
    [Tooltip("In meters")] [SerializeField] float xRange = 2.5f;

    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 6.0f;
    [Tooltip("In meters")] [SerializeField] float yRange = 2.5f;

    [SerializeField] float positionPitchFactor = -5.0f;
    [SerializeField] float positionYawFactor = 5.0f;

    [SerializeField] float controlPitchFactor = -30.0f;
    [SerializeField] float controlRollFactor = -15.0f;

    float xThrow, yThrow;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        print("Player collided with something");
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRaw = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yRaw = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xRaw, yRaw, transform.localPosition.z);
    }
}
