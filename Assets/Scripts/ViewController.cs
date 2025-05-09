using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//view controller-- control the view of canmera
public class ViewController : MonoBehaviour
{
    public float speed = 10;//the speed of the key board
    public float mouse_speed = 60;//speed o fthe mouse scorll
    public float Max_Y = 70f;//the Max distance of Y
    public float Min_Y = -1f;//the min distance ofy
    public float Max_Z = 90f;//the max fistance of z
    public float Min_Z = -90f;//the min distance of z
    public float Max_X = 80f;//the max distance of x
    public float Min_X = -80f;//the min distanceof x

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");//get horiontal move 
        float v = Input.GetAxis("Vertical");//get vertical move
        float mouse = Input.GetAxis("Mouse ScrollWheel");//get up and down move
        //get the move distance
        Vector3 move = new Vector3(h*speed, mouse*mouse_speed, v*speed) *Time.deltaTime;//update the positon of the camera

        //get new position
        Vector3 newposiotn = transform.position+ move;

        //limit the postion of the camera
        newposiotn.x = Mathf.Clamp(newposiotn.x,Min_X,Max_X);
        newposiotn.y = Mathf.Clamp(newposiotn.y, Min_Y, Max_Y);
        newposiotn.z = Mathf.Clamp(newposiotn.z,Min_Z,Max_Z);

        //update thenew postion
        transform.position = newposiotn;

    }
}
