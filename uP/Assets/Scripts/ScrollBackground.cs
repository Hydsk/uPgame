using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 5f;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //19.2 posição de X do filho
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 19.2f);
        transform.position = startPos + Vector2.up * newPos;
    }
}
