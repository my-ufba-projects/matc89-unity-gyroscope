using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip ("In m/s^-1")][SerializeField] float controlSpeed = 17f;
    [SerializeField] float horizontalLimit = 6.2f;
    [SerializeField] float verticalLimit = 4.0f;

    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Throw")]
    [SerializeField] float controlPitchFactor = -17;
    [SerializeField] float controlRollFactor = -20f;

    private float ThrowHor;
    private float ThrowVer;
    private bool isControlEnabled = true;
    

    // Update is called once per frame
    void Update ()
    {
        if(isControlEnabled)
            TranslatingShip();
            RotatingShip(); // pitch = x, yaw = y, roll = z
    }

    private void StartDying() // called by string reference (hardcoded), care when refactoring this method
    {
        isControlEnabled = false;
    }

    private void TranslatingShip()
    {
        float rawNewPosHor = MoveHorizontally();
        float rawNewPosVer = MoveVertically();

        transform.localPosition = new Vector3(rawNewPosHor, rawNewPosVer, transform.localPosition.z);
    }

    private float MoveVertically()
    {
        ThrowVer = CrossPlatformInputManager.GetAxis("Vertical");
        float Offset2Ver = ThrowVer * controlSpeed * Time.deltaTime;
        float rawNewPosVer = transform.localPosition.y + Offset2Ver;
        rawNewPosVer = Mathf.Clamp(rawNewPosVer, -verticalLimit, verticalLimit);
        return rawNewPosVer;
    }

    private float MoveHorizontally()
    {
        ThrowHor = CrossPlatformInputManager.GetAxis("Horizontal");
        float OffsetHor = ThrowHor * controlSpeed * Time.deltaTime;
        float rawNewPosHor = transform.localPosition.x + OffsetHor;
        rawNewPosHor = Mathf.Clamp(rawNewPosHor, -horizontalLimit, horizontalLimit);
        return rawNewPosHor;
    }

    private void RotatingShip()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = ThrowVer * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = ThrowHor * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
