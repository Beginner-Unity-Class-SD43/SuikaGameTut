using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLineController : MonoBehaviour
{
    [SerializeField] Transform fruitThrowTransform;
    [SerializeField] Transform bottomTransform;

    LineRenderer lineRenderer;

    float topPos;
    float bottomPos;
    float xPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = fruitThrowTransform.position.x;
        topPos = fruitThrowTransform.position.y;
        bottomPos = bottomTransform.position.y;

        lineRenderer.SetPosition(0, new Vector3(xPos, topPos));
        lineRenderer.SetPosition(1, new Vector3(xPos, bottomPos));
    }
}
