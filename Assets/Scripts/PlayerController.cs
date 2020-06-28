using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In meters per second")] [SerializeField] float speed = 6.0f;
    [Tooltip("In meters")] [SerializeField] float xRange = 2.5f;
    [Tooltip("In meters")] [SerializeField] float yRange = 2.5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5.0f;
    [SerializeField] float positionYawFactor = 5.0f;

    [Header("Controle-throw Based")]
    [SerializeField] float controlPitchFactor = -30.0f;
    [SerializeField] float controlRollFactor = -15.0f;

    float xThrow, yThrow;
    bool controlsEnabled = true;

    void Start()
    {
    }

    void Update()
    {
        if (controlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessShooting();
        }
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
        float xOffset = xThrow * speed * Time.deltaTime;
        float xRaw = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float yRaw = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xRaw, yRaw, transform.localPosition.z);
    }

    private void ProcessShooting()
    {
        foreach (GameObject gun in guns)
        {
            var emissionComponent = gun.GetComponent<ParticleSystem>().emission;
            emissionComponent.enabled = CrossPlatformInputManager.GetButton("Fire");
        }
    }

    public void OnPlayerDeath() // called by string reference
    {
        controlsEnabled = false;
    }
}
