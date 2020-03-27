using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 4.0f;
    [Tooltip("In meters")] [SerializeField] float xRange = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xRaw = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        transform.localPosition = new Vector3(xRaw, transform.localPosition.y, transform.localPosition.z);
    }
}
