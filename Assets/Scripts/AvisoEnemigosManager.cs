using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoEnemigosManager : MonoBehaviour
{

    [SerializeField]
    GameObject rinoWarning;

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

    public void SwitchWarningZone(EnemyTypeEnum enemyTypeEnum ,bool activate)
    {
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                rinoWarning.SetActive(activate);
                break;
            default:
                break;
        }

    }
}
