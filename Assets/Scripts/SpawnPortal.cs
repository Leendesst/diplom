using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    [SerializeField] private List<Transform> _listSpawn = new List<Transform>();
    [SerializeField] private GameObject _portal;


    void Start()
    {
        
        int rnd = Random.Range(0,3);
        
        Instantiate(original: _portal,position: _listSpawn[rnd].position, rotation: Quaternion.identity, parent: _listSpawn[rnd]);
    }

}
