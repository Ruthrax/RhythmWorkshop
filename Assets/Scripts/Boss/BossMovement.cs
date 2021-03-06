using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BossMovement : MonoBehaviour
{
    bool goRight;
    bool isMovingSide;
    [SerializeField] bool goCenter;
    [SerializeField] bool goUp;
    public bool isUp;

    Vector3 pos;
    [SerializeField] float speed;
    [SerializeField] float speedMov;
    [SerializeField] float maxX;
    float time;
    float x;

    [SerializeField] Transform centerMap;
    [SerializeField] Transform upMap;

    float chrono;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        isMovingSide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingSide == true)
        {
            time += Time.deltaTime;
            x = maxX * Mathf.Sin(speed * time);
            transform.localPosition = new Vector3(pos.x + x, pos.y, pos.z);
        }

        if (goCenter == true)
        {
            StartCoroutine(MoveToCenter());
            chrono += Time.deltaTime;
        }
        if (goUp == true)
        {
            StartCoroutine(MoveToUp());
            chrono += Time.deltaTime;
        }
    }

    IEnumerator MoveToCenter()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, centerMap.position.x, chrono * speedMov), Mathf.Lerp(transform.position.y, centerMap.position.y, chrono * speedMov));

        isMovingSide = false;
        goCenter = true;

        if (transform.position == centerMap.position)
        {
            transform.position = centerMap.position;
            goCenter = false;
            chrono = 0;
            isUp = false;
            StopCoroutine(MoveToCenter());
        }
        yield return null;
    }

    IEnumerator MoveToUp()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, upMap.position.x, chrono * speedMov), Mathf.Lerp(transform.position.y, upMap.position.y, chrono * speedMov));

        goUp = true;

        if (transform.position == upMap.position)
        {
            transform.position = upMap.position;
            goUp = false;
            isMovingSide = true;
            chrono = 0;
            time = 0;
            isUp = true;
            x = pos.x;
            pos = transform.position;
            StopCoroutine(MoveToUp());
        }

        yield return null;
    }

    public void Move()
    {
        if (isUp == true)
        {
            StartCoroutine(MoveToCenter());
        }
        if (isUp == false)
        {
            StartCoroutine(MoveToUp());
        }
    }
}
