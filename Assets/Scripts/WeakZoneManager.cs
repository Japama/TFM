using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakZoneManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var enemyType = gameObject.GetComponentInParent<EnemyChecker>().enemyType;
            switch (enemyType)
            {
                case EnemyTypeEnum.Rino:
                    gameObject.GetComponentInParent<RinoManager>().Hitted();
                    break;
                case EnemyTypeEnum.AngryPig:
                    gameObject.GetComponentInParent<AngyPigManager>().Hitted();
                    break;
                default:
                    break;
            }
        }
    }
}
