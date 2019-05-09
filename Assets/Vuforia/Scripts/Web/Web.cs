using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Web : MonoBehaviour
{
    public virtual void OnWebConnected(){}

    public virtual void OnWebLoad(){}
}
