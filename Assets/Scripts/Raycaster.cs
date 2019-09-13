using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    RaycastHit hit;
    Ray ray;

    private void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Input.mousePosition, ray.direction);

        // When mouse is over a valid gameobject.
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if (Input.GetMouseButton(0))
            {

            }
        }
    }
}
