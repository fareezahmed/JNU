﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float destoryDelayTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destoryDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
