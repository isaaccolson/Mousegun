using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextObject : MonoBehaviour
{
    public float counter;
    
    // Start is called before the first frame update
    void Start()
    {
      counter = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = ((counter - 4)*(counter - 4) + 1);
        //transform.localPosition = new Vector3(transform.position.x, newPosition);
        
        transform.localPosition = new Vector3(transform.localPosition.x, 50*(float)Math.Sin(counter));
        counter += 0.05f;
    }
}
