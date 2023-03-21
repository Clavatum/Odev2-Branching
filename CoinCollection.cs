using System.Collections;
using UnityEngine;
using CoinRandom;
using System.Linq;
using System;

public class CoinCollection : MonoBehaviour
{
    private SpawnPointController spawner;
    [SerializeField] private GameObject _gameObject;
    private AudioSource click;
    private int totalSpawnPoints;
    int y;


    private void Start()
    {
        click = GetComponent<AudioSource>();

        //_musicFiles = _music.GetComponent(typeof(MusicFiles)) as MusicFiles; ( ORNEK )
        spawner = _gameObject.GetComponent(typeof(SpawnPointController)) as SpawnPointController; // Icerisinde SpawnPointController script'i bulunduran obeji bulmaya yarar **********

        totalSpawnPoints = spawner.spawnPoints.Count();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))// other.gameObject collider component'inin var olduðu objeyi tarif eder.
        {
            //Destroy(other.gameObject); // Objeyi yok edip sonra tekrarda instantiate etmek yerine aktifligi ile oynamak daha optimize olmasini saglar
            other.gameObject.SetActive(false); 
            
            click.Play();

            StartCoroutine(Spawn(other.gameObject));
        }
    }

    IEnumerator Spawn(GameObject gameObject)
    {
        //Debug.Log(spawner.spawnPoints.IndexOf(gameObject.transform.parent.transform)); //Deactive edilen nesnenin dogrusu olup olmadigini kontrol eder

        int x = spawner.spawnPoints.IndexOf(gameObject.transform.parent.transform);
        //3 saniye sonra obje tekrardan aktiflesecek

        spawner.randomValues.Remove(x);



        yield return new WaitForSeconds(3);

        while (spawner.randomValues.Count < Math.Ceiling(totalSpawnPoints / 2.0f))
        {
            y = spawner.r.Next(0, spawner.spawnPoints.Count() - 1);
            spawner.randomValues.Add(y);
        }

        gameObject.SetActive(true);
        gameObject.transform.position = spawner.spawnPoints[y].transform.position;

    }
}

 