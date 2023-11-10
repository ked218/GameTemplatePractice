using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOwn
{
    Type OwnType { set; } 
    MonoBehaviour Own { set; }
}
