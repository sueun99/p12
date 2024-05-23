using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimeout_DestroyMe : MonoBehaviour
{
    public float limitSec = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,limitSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
