using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int FruitIndex = 0;
    public int PointsWhenCombined = 1;
    public float fruitMass = 1f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = fruitMass;
    }
}
