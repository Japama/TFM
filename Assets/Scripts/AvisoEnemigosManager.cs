using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvisoEnemigosManager : MonoBehaviour
{

    public GameObject rinoWarning;
    public GameObject pigWarning;
    public GameObject turtleWarning;

    private Image turtleImage;

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

        turtleImage = turtleWarning.GetComponent<Image>();
    }

    public void SwitchWarningZone(EnemyTypeEnum enemyTypeEnum, bool activate)
    {
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                rinoWarning.SetActive(activate);
                break;
            case EnemyTypeEnum.AngryPig:
                pigWarning.SetActive(activate);
                break;
            case EnemyTypeEnum.Turtle:
                turtleWarning.SetActive(activate);
                break;
            default:
                break;
        }

        if (activate)
            TurnOnFade(enemyTypeEnum);
        else
            TurnOffFade(enemyTypeEnum);
    }

    private void TurnOnFade(EnemyTypeEnum enemyTypeEnum)
    {
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                break;
            case EnemyTypeEnum.AngryPig:
                break;
            case EnemyTypeEnum.Turtle:
                InvokeRepeating(nameof(FadeOutTurtle), 0, 2);
                InvokeRepeating(nameof(FadeInTurtle), 1, 2);
                break;
            default:
                break;
        }
    }

    private void TurnOffFade(EnemyTypeEnum enemyTypeEnum)
    {
        switch (enemyTypeEnum)
        {
            case EnemyTypeEnum.Rino:
                break;
            case EnemyTypeEnum.AngryPig:
                break;
            case EnemyTypeEnum.Turtle:
                CancelInvoke(nameof(FadeOutTurtle));
                CancelInvoke(nameof(FadeInTurtle));
                break;
            default:
                break;
        }
    }

    private void FadeInTurtle()
    {
        turtleImage.CrossFadeAlpha(1f, 1f, true);
    }

    private void FadeOutTurtle()
    {
        turtleImage.CrossFadeAlpha(0f, 1f, true);
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
            case EnemyTypeEnum.Turtle:
                if (turtleWarning.transform.localScale.x < 1)
                    turtleWarning.transform.localScale = newSize;
                break;
            default:
                break;
        }
    }
}
