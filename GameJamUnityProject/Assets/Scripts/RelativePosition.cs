using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RelativePosition : MonoBehaviour 
{
    public float x, y;

    void Update()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 0));
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
