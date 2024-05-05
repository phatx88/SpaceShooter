using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 1f;
    public float flipCooldown = 2f; // Cooldown in seconds between flips

    private float lastFlipTime = -Mathf.Infinity; // Track the last time the ship flipped



    //Add Invulnerability to flip 
    DamageController damageController;
    private void Awake()
    {

        damageController = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageController>();
    }

    //float shipBoundaryRadius = 0.5f;
    void Start()
    {

    }

    void Update()
    {   
        //Rotate the Ship Horizontally
        Quaternion rot = RotateShip();

        //Move Ship vertically
        MoveShip(rot);

        //Flip Ship to dogfight
        // Check if the space key is pressed to flip the ship
        if (Input.GetButtonDown("Jump") && Time.time >= lastFlipTime + flipCooldown)
        {
            StartCoroutine(FlipShip());
            lastFlipTime = Time.time; // Update the last flip time
            damageController.TriggerInvulnerability(false, 1f); //Set false to avoid reduce Health
            AudioControler.Instance.PlaySFX("FlipShip"); //Add Flip sound
        }


        #region RESTRICT PLAYER BOUNDARY 

        ////Do Vertical boundary based on Main Camera(tagged with Main Camera) Orthographic(default is 5)
        //if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        //{
        //    pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        //}

        //if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        //{
        //    pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        //}


        ////Do Horizontal vertical based on aspect ration of screen size
        //float screenRatio = (float)Screen.width / (float)Screen.height;
        //float widtOrtho = Camera.main.orthographicSize * screenRatio;

        //if (pos.x + shipBoundaryRadius > widtOrtho)
        //{
        //    pos.x = widtOrtho - shipBoundaryRadius;
        //}

        //if (pos.x - shipBoundaryRadius < -widtOrtho)
        //{
        //    pos.x = -widtOrtho + shipBoundaryRadius;
        //}
        //transform.position = pos;
        #endregion


    }

    public Quaternion RotateShip()
    {
        #region ROTATE the Ship
        //Assign rotation quaternion
        Quaternion rot = transform.rotation;

        //Assign the Z euler angle
        float z = rot.eulerAngles.z;

        //Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed + Time.deltaTime;

        //Initiate z change in the quaternion
        rot = Quaternion.Euler(0, 0, z);

        //transform rotation
        transform.rotation = rot;
        #endregion
        return rot;
    }

    public void MoveShip(Quaternion rot)
    {
        #region MOVE the Ship
        //Use Vertical as in Input manager to get value up and down from variety of device such as mobile and joystick
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;

        #endregion
    }

    #region ADDING Flip Ability

    private IEnumerator FlipShip()
    {
        // Get the current rotation and scale of the ship
        float startAngle = transform.rotation.eulerAngles.z;
        float endAngle = startAngle + 180f; // Target angle after flipping

        float duration = .5f; // Total time to complete the flip
        float time = 0;

        Vector3 startScale = transform.localScale; // Assuming the ship starts at normal scale
        Vector3 minScale = new Vector3(startScale.x, 0, startScale.z); // Scale down to 0 on the y-axis

        while (time < duration)
        {
            // Interpolate the rotation angle over time
            float angle = Mathf.Lerp(startAngle, endAngle, time / duration);
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Interpolate the scale
            if (time <= duration / 2)
            {
                // Scale down to zero in the first half of the animation
                transform.localScale = Vector3.Lerp(startScale, minScale, (time / (duration / 2)));
            }
            else
            {
                // Scale back to original scale in the second half of the animation
                transform.localScale = Vector3.Lerp(minScale, startScale, ((time - (duration / 2)) / (duration / 2)));
            }

            // Increment the time elapsed
            time += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // Ensure the rotation and scale are exactly as intended at the end
        transform.rotation = Quaternion.Euler(0, 0, endAngle);
        transform.localScale = startScale;
        
    }

    #endregion
}