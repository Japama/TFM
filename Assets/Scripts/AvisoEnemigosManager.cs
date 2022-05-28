using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoEnemigosManager : MonoBehaviour
{

    public GameObject rinoWarning;
    public GameObject pigWarning;

    public bool gettingCloser = false;

    public static AvisoEnemigosManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SwitchWarningZone(EnemyTypeEnum enemyTypeEnum, bool activate)
    {
        gettingCloser = activate;
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                rinoWarning.SetActive(activate);
                break;
            case EnemyTypeEnum.AngryPig:
                pigWarning.SetActive(activate);
                break;
            default:
                break;
        }
    }

    public void SetWarningSize(EnemyTypeEnum enemyTypeEnum, Vector3 newSize)
    {
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                if (rinoWarning.transform.localScale.x < 1)
                    rinoWarning.transform.localScale = newSize;
                break;
            case EnemyTypeEnum.AngryPig:
                if (pigWarning.transform.localScale.x < 1)
                    pigWarning.transform.localScale = newSize;
                break;
            default:
                break;
        }
    }
}
