using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 5f;

    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawnFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] GameObject[] Guns;



    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring(); //fireee
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = (transform.localPosition.y * positionPitchFactor);
        float pitchDueToControlThrow = (yThrow * controlPitchFactor);
        float pitch = pitchDueToControlThrow + pitchDueToPosition;

        float yaw = transform.localPosition.x * positionYawnFactor;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //throw: mennyire van kilengve a joystick 
        //float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //0 és 1 és 0 és -1 közöt mozog Sensitivity hogy milyen gyorsan megy fel,
        //es Gravity hogy milyen gyorsan megy le
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime; //ThisFrame
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; //jelenlegi X-et változtatjuk xOffsettel
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //bizonyos határok közé rakja !!local position!!!

        float rawYPos = transform.localPosition.y + yOffset; //jelenlegi X-et változtatjuk xOffsettel
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); //bizonyos határok közé rakja !!local position!!!
        //jelenlegi pozicio X koordinátáját változtatjuk egyedul
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //jelenlegi pozicio X koordinátáját változtatjuk egyedul
    }

    void OnPlayerDeath() // called by string reference
    {
        print("Controls frozen");
        isControlEnabled = false;
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {

            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in Guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

}
