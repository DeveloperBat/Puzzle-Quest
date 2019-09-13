using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationSpeed = new Vector3(0,0,0);

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = Rotation();
        StartCoroutine(coroutine);
    }

    private void OnDestroy()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            transform.Rotate(rotationSpeed.x, rotationSpeed.y, rotationSpeed.z);
            yield return null;
        }
    }
}
