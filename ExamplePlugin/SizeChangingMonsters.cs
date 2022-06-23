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

        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "YoboPlays";
        public const string PluginName = "PressButtonSpawnMonster";
        public const string PluginVersion = "1.0.1";
        public static ConfigEntry<string> MonsterOne { get; set; }
        public static ConfigEntry<string> MonsterTwo { get; set; }
        public static ConfigEntry<string> MonsterThree { get; set; }
        public static ConfigEntry<string> MonsterFour { get; set; }
        public static ConfigEntry<string> MonsterFive { get; set; }
        public static ConfigEntry<string> MonsterSix { get; set; }
        public static ConfigEntry<string> MonsterSeven { get; set; }
        public static ConfigEntry<string> MonsterEight { get; set; }
        public static ConfigEntry<string> MonsterNine { get; set; }
        public static ConfigEntry<string> MonsterTen { get; set; }
        public static ConfigEntry<string> MonsterList { get; set; }

        public void Awake()
        {
            MonsterOne = Config.Bind<string>(
                "Monster A (F1)",
                "Monster you want to spawn",
                "BeetleMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterTwo = Config.Bind<string>(
                "Monster B (F2)",
                "Monster you want to spawn",
                "LemurianMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterThree = Config.Bind<string>(
                "Monster C (F3)",
                "Monster you want to spawn",
                "BeetleGuardMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterFour = Config.Bind<string>(
                "Monster D (F4)",
                "Monster you want to spawn",
                "WispMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterFive = Config.Bind<string>(
                "Monster E (F5)",
                "Monster you want to spawn",
                "GreaterWispMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterSix = Config.Bind<string>(
                "Monster F (F6)",
                "Monster you want to spawn",
                "LemurianBruiserMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterSeven = Config.Bind<string>(
                "Monster G (F7)",
                "Monster you want to spawn",
                "GolemMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterEight = Config.Bind<string>(
                "Monster H (F8)",
                "Monster you want to spawn",
                "NullifierMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterNine = Config.Bind<string>(
                "Monster I (F9)",
                "Monster you want to spawn",
                "ScavMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterTen = Config.Bind<string>(
                "Monster J (F10)",
                "Monster you want to spawn",
                "BrotherMaster",
                "capitalize the first letter, no spaces, use the wiki name of the enemy + Master"
                );
            MonsterList = Config.Bind<string>(
                "List of Monster Names",
                "Pick one of these names to spawn",
                "xxxxx",
                "AcidLarva, AncientWispMonster, Beetle, Beetle Guard, Lemurian, LemurianBruiser, BeetleQueen, Bell, Bison, Brother, ClayBoss, ClayBruiser, Clayman, FlyingVermin, Golem, GrandParentBoss, GravekeeperBoss, Wisp, GreaterWisp, Gup, HermitCrab, Imp, ImpBoss, Jellyfish, LunarExploder, LunarGolem, LunarWisp, MagmaWorm, MiniMushroom, Nullifier, Parent, RoboBallBoss, Scav, Titan, Vagrant, Vermin, VoidBarnacle, VoidInfestor, VoidJailer, VoidMegaCrab, Vulture"
                );

            Log.Init(Logger);

         
        }

        private void Update()
        {
            Vector3 charPosition = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform.position;
            Vector3 playerPosition = charPosition + new Vector3(0, 5, 0);


            if (Input.GetKeyDown(KeyCode.F1))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterOne.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterTwo.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterThree.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterFour.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterFive.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterSix.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterSeven.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterEight.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterNine.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterTen.Value),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();


            }
        }
    }

}
