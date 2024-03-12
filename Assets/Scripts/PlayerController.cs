using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider2D boundaries;
    [SerializeField] Transform fruitThrowTransform;

    Bounds bounds;
    float leftBound;
    float rightBound;

    float startingLeftBound;
    float startingRightBound;

    float offset;

    private void Awake()
    {
        bounds = boundaries.bounds;
        offset = transform.position.x - fruitThrowTransform.position.x;

        leftBound = bounds.min.x + offset;
        rightBound = bounds.max.x + offset;

        startingLeftBound = leftBound;
        startingRightBound = rightBound;
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, leftBound, rightBound);
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    }

    public void ChangeBoundary(float extrawidth)
    {
        leftBound = startingLeftBound;
        rightBound = startingRightBound;

        leftBound += ThrowFruitController.instance.Bounds.extents.x + extrawidth;
        rightBound -= ThrowFruitController.instance.Bounds.extents.x + extrawidth;
    }
}
