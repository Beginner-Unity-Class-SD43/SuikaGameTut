using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn { get; set; }

    bool hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!hasCollided && !WasCombinedIn)
        {
            hasCollided = true;
            ThrowFruitController.instance.CanThrow = true;
            ThrowFruitController.instance.SpawnFruit(FruitSelector.instance.NextFruit);
            FruitSelector.instance.PickNextFruit();
            Destroy(this);
        }
    }
}
