using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour
{
    public Transform[] background;      //array (list) of all the back- and foreground that need to be parallax
    private float[] parallaxSxales;     // the proportion of the camera to the background by
    public float smoothing = 1f;             //How smooth the parallax is going to be

    private Transform cam;              // Reference to the main camera transform
    private Vector3 previousCamPos;    //the position of the camera in privious frame

    //called before start
    void Awake()
    {
        //set up the camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //the previous frame has the current cameras position
        previousCamPos = cam.position;

        //assigning corresponding effects
        parallaxSxales = new float[background.Length];
        for (int i = 0; i<background.Length; i++)
        {
            parallaxSxales[i] = background[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for each background
        for(int i = 0; i<background.Length; i++)
        {
            //the parallax is the opposite of the camera movement because the previous frame is multiplied by scales
            float parallax = (previousCamPos.x - cam.position.x) * parallaxSxales[i];

            //set a target x position which is the current position + the parallax
            float backgrountTargetPosX = background[i].position.x + parallax;

            //create a target position which is the background current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgrountTargetPosX, background[i].position.y, background[i].position.z);

            //fade between current pos and the target pos using lerp
            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set the previous cam pos to the camera pos at the end of the frame
        previousCamPos = cam.position; 
    }
}
