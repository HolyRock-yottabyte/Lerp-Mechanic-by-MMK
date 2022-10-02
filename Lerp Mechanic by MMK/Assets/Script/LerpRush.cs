using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LerpRush : MonoBehaviour
{
    public static LerpRush instance;

    public List<GameObject> cubes = new List<GameObject>();

    public float movementDelay = 0.25f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackObj(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cubes.Add(other);

        StartCoroutine(MakeObjectsBigger());

    }

    public IEnumerator MakeObjectsBigger()
    {
        for (int i = cubes.Count-1; i>0; i--)
        {
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.2f;
            int index = i;

            cubes[i].transform.DOScale(scale, 0.1f).OnComplete(() =>
            cubes[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i <cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, movementDelay); 
        }
    }

    
    private void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 1f);
        }
    }
}
