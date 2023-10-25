using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//obtained from https://www.youtube.com/watch?v=ZBj3LBA2vUY&t=23s&pp=ygUec21vb3RoIGNhbWVyYSBmb2xsb3cgdW5pdHkgMmQj

//allows for a smooth camera follow, which attach makes it less shake with your character
public class Cameramijigger : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
