using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 4.0f;
    [Tooltip("In meters")] [SerializeField] float xRange = 2.5f;

    [Tooltip("In meters per second")] [SerializeField] float ySpeed = 4.0f;
    [Tooltip("In meters")] [SerializeField] float yRange = 2.5f;

    void Start()
    {
        
    }

    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRaw = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yRaw = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xRaw, yRaw, transform.localPosition.z);
    }
}
