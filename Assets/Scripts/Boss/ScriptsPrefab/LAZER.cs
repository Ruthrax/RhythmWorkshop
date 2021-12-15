using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZER : MonoBehaviour
{
    Pool source;
    float chrono;

    [SerializeField] float speed;
    [SerializeField] float speedLazerMove;
    [SerializeField] float maxLife;
    Vector2 moveLazer;

    [SerializeField] GameObject preLazer;
    [SerializeField] GameObject child;

    [SerializeField] Material alphaChange;
    Material changeMat;
    public Color color = new Color();
    // Start is called before the first frame update

    private void Start()
    {
        chrono = maxLife;
        moveLazer = child.transform.localPosition;

        changeMat = new Material(alphaChange);
        color = changeMat.color;
        color.a = 0.1f;
        changeMat.color = color;
        preLazer.GetComponent<SpriteRenderer>().material = changeMat;
    }

    private void Update()
    {
        color = changeMat.color;
        color.a += 1f * Time.deltaTime * speed;
        changeMat.color = color;

        moveLazer.x += Time.deltaTime*speedLazerMove;
        child.transform.localPosition = moveLazer;

        if (chrono <= 0)
        {
            LAZERSpawn();
            chrono = maxLife;
        }
        chrono -= Time.deltaTime;
    }

    public void Spawn(Pool pool)
    {
        child.SetActive(false);
        source = pool;
    }

    public void Return(Pool pool)
    {
        color = changeMat.color;
        color.a = 0.1f;
        changeMat.color = color;
        child.SetActive(false);
        source.Back(gameObject);
    }

    void LAZERSpawn()
    {
        child.SetActive(true);
    }
}
