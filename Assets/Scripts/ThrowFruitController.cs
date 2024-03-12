using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFruitController : MonoBehaviour
{
    public static ThrowFruitController instance;

    public GameObject CurrentFruit { get; set; }
    [SerializeField] Transform fruitTransform;
    [SerializeField] Transform parentAfterThrow;
    [SerializeField] FruitSelector selector;

    PlayerController playerController;

    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    public Bounds Bounds { get; private set; }

    private const float EXTRA_WIDTH = 0.02f;

    public bool CanThrow { get; set; } = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        SpawnFruit(selector.PickRandomFruitForThrow());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.instance.Fruits[index.Index], CurrentFruit.transform.position, rot);
            go.transform.SetParent(parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }

    public void SpawnFruit(GameObject fruit)
    {
        GameObject go = Instantiate(fruit, fruitTransform);
        CurrentFruit = go;
        circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = circleCollider.bounds;

        playerController.ChangeBoundary(EXTRA_WIDTH);
    }
}
