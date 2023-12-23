using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOFF : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mesh;
    public void OnOff()
    {
        if(mesh.enabled)
        {
            mesh.enabled = false;
        }
        else
        {
            mesh.enabled = true;
        }
    }
}
