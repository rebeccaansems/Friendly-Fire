using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICreditController : UIController
{
    public static UICreditController instance;

    private void Awake()
    {
        instance = this;
    }
}
