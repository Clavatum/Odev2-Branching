using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;


namespace CoinRandom
{
    public class SpawnPointController : MonoBehaviour
    {
        public List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] private GameObject coin;
        public HashSet<int> randomValues = new HashSet<int>(); //"Random olarak sayýlar üretmek istiyor ve bu ürettiðim sayýlarý bir listeye kayýt etmek istiyorum fakat bu listede tekrar eden sayýlar istemiyorum"= List'ten farký
        public Random r = new Random();

        private void Start()
        {
            

            int a = (int)Math.Ceiling(spawnPoints.Count / 2.0f);


            while (randomValues.Count < a)
            {
                randomValues.Add(r.Next(0, spawnPoints.Count() - 1));
            }

            //var randomValues = Enumerable.Range(0, a)
            //.Select(e => spawnPoints[r.Next(spawnPoints.Count)]);

            //Debug.Log(randomValues.Count());

            foreach (var x in randomValues)
            {
                //Debug.Log(spawnPoints[x]);
                Instantiate(coin, spawnPoints[x]);
            }
        }
    }

}
