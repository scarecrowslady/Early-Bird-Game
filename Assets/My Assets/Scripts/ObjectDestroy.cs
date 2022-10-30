using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestructObject());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SelfDestructObject()
    {
        yield return new WaitForSeconds(timeLeft);
        Destroy(gameObject);
    }
}
