using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m^-1")][SerializeField] float controllSpeed = 55f;
    [Tooltip("In m^-1")][SerializeField] float xRange = 25f;
    [Tooltip("In m^-1")][SerializeField] float yRange = 12f;

    [Header("Screen-postion Based")]
    [SerializeField] float positionPitchFactor = -0.15f;
    [SerializeField] float positionYawFactor = -1f;
    

    [Header("Controll-throw Based")]
    [SerializeField] float controlRollFactor = -15f;
    [SerializeField] float controlPitchFactor = -2f;
    float xThrow, yThrow;

    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled == true) 
        {
            ProcessTranslation();
            ProcessRotation();
        }
        
    }

    void OnPlayerDeath() // Called in Collision Handler by Send Message 
    {
        isControlEnabled = false;
    }
    private void ProcessRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        
        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controllSpeed * Time.deltaTime;
        float rawXPos  = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * 10 *  Time.deltaTime;
        float rawYPos  = transform.localPosition.y + yOffset;
        // print("yThrow user input " + yThrow);
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        // print("Time.deltaTime" + Time.deltaTime);
        // print("transform.localPosition.y" + transform.localPosition.y);
        // print("yOffset" + yOffset);
        // print("rawYPos" + rawYPos);
        // print("clampYPos" + clampYPos);
        // transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);

        transform.localPosition = new Vector3(clampXPos, 0, transform.localPosition.z);
        
    }


}
