using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZoneController : MonoBehaviour
{
    public EnemyTypeEnum EnemyType;
    public List<GameObject> Enemies;
    [SerializeField]
    private Transform Center;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count <= 0)
        {
            AvisoEnemigosManager.Instance.SwitchWarningZone(EnemyType, activate: false);
            playerManager.RemoveWarningController(EnemyType);
            GameObject.Destroy(gameObject);
        }
    }

    public void DeleteEnemy(GameObject enemy)
    {
        Enemies.Remove(enemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && AdaptacionesManager.Avisar)
        {
            AvisoEnemigosManager.Instance.SwitchWarningZone(EnemyType, activate: true);
            playerManager.AddWarningController(EnemyType, Center);
        }
    }

}
