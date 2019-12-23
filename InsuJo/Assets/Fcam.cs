using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fcam : MonoBehaviour
{
    public Transform target;
    public float height = 90;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = target.position + Vector3.up * height;
        tr.LookAt(target);
    }
}
