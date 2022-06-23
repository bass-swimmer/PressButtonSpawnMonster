using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;
using System.Collections;
using UnityEngine.AddressableAssets;
using BepInEx.Configuration;

namespace PushButtonSpawnMonster
{

    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.YoboPlays.PressButtonSpawnMonster", "PressButtonSpawnMonster", "1.0.1")]

    public class SpawningMonsters : BaseUnityPlugin
    {

        public void Awake()
        {
            Log.Init(Logger);

        }

        private void Update()
        {
            


            }
        }
    }

}
