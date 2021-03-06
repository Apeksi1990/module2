using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, ISaveable
{
    public Transform start;
    public Transform end;
    public float speed;

    private float current;  // от 0.0 до 1.0
    private float dir;

    // Start is called before the first frame update
    void Start()
    {
        current = 0.0f;
        dir = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        current += dir * speed * Time.deltaTime;
        if (current > 1.0f) {
            current = 1.0f;
            dir = -1.0f;
        } else if (current < 0.0f) {
            current = 0.0f;
            dir = 1.0f;
        }

        transform.position = Vector3.Lerp(start.position, end.position, current);
    }

    void ISaveable.Save(GameState gameState)
    {
        gameState.platformState.current = current;
        gameState.platformState.dir = dir;
    }

    void ISaveable.Restore(GameState gameState)
    {
        current = gameState.platformState.current;
        dir = gameState.platformState.dir;
    }
}
