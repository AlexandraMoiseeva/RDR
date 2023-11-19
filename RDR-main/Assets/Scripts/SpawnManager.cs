using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> startSpawnPoints;
    //public List<GameObject> spawnPoints;
    public GameObject player;

    private void Awake()
    {
        int spawnPointIndex = Random.Range(0, startSpawnPoints.Count - 1);
        GameObject currSpawnPoint = startSpawnPoints[spawnPointIndex];
        Vector3 ramdomPosition = currSpawnPoint.transform.localPosition;
        PhotonNetwork.Instantiate(player.name, ramdomPosition, Quaternion.identity);
    }
}
