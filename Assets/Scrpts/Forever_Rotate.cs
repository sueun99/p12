using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_Rotate : MonoBehaviour
{
    public bool x_bool = false;
    public bool y_bool = false;
    public bool z_bool = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x_angle = 0;
        float y_angle = 0;
        float z_angle = 0;

        if (x_bool == true)
        {
            x_angle = 90;
        }
        if (y_bool == true)
        {
            y_angle = 90;
        }
        if (z_bool == true)
        {
            z_angle = 90;
        }

        this.transform.Rotate(x_angle / 50, y_angle / 50, z_angle / 50);
    }
}
