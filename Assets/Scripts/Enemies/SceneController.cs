using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy_001;

    [SerializeField]private GameObject enemy_nachoBeast;
    private GameObject _enemy_002;

    [SerializeField]private GameObject enemy_hotdogTrapper;
    private GameObject _enemy_003;

    [SerializeField]private GameObject enemy_saladShooter;
    private GameObject _enemy_004;

    void Update ()
    {
       if (_enemy_001 == null)
        {
            _enemy_001 = Instantiate (enemyPrefab) as GameObject;
            _enemy_001.transform.position = new Vector3 (0,1,0);
            float angle = Random.Range (0,360);
            _enemy_001.transform.Rotate (0, angle, 0);
        }

        if (_enemy_002 == null)
        {
            _enemy_002 = Instantiate (enemy_nachoBeast) as GameObject;
            _enemy_002.transform.position = new Vector3 (6,1.07f,0);
            float angle = Random.Range (0,360);
            _enemy_002.transform.Rotate (0, angle, 0);
        }

       if (_enemy_003 == null)
        {
            _enemy_003 = Instantiate (enemy_hotdogTrapper) as GameObject;
            _enemy_003.transform.position = new Vector3 (6,1,16);
            float angle = Random.Range (0,360);
            _enemy_003.transform.Rotate (0, angle, 0);
        }

        if (_enemy_004 == null)
        {
            _enemy_004 = Instantiate (enemy_saladShooter) as GameObject;
            _enemy_004.transform.position = new Vector3 (8,1,-23);
            float angle = Random.Range (0,360);
            _enemy_004.transform.Rotate (0, angle, 0);
        }


    }





}
