using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesManager : MonoBehaviour
{
    [SerializeField]
    GameObject Life1;

    [SerializeField]
    GameObject Life2;

    [SerializeField]
    GameObject Life3;

    GameObject[] Lifes;

    const int MaxLifes = 3;

    int NumberOFLifes;

    // Start is called before the first frame update
    void Start()
    {
        Lifes = new GameObject[MaxLifes];
        Lifes[0] = Life1;
        Lifes[1] = Life2;
        Lifes[2] = Life3;
        NumberOFLifes = MaxLifes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        NumberOFLifes--;
        var hearts = Lifes[NumberOFLifes].GetComponentsInChildren(typeof(Image), true);
        foreach (var heart in hearts)
        {
            if (heart.name.Contains("Full"))
                heart.gameObject.SetActive(false);
            else
                heart.gameObject.SetActive(true);
        }
    }

    public void RefillLifes()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            var hearts = Lifes[i].GetComponentsInChildren(typeof(Image), true);
            foreach (var heart in hearts)
            {
                if (heart.name.Contains("Full"))
                    heart.gameObject.SetActive(true);
                else
                    heart.gameObject.SetActive(false);
            }
        }
        NumberOFLifes = MaxLifes;
    }
}
