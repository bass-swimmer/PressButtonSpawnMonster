using BepInEx;
using RoR2;
using UnityEngine;
using BepInEx.Configuration;
using System;

namespace PushButtonSpawnMonster
{

    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.YoboPlays.PressButtonSpawnMonster", "PressButtonSpawnMonster", "1.1.0")]

    public class MonsterSpawner : BaseUnityPlugin
    {

        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "YoboPlays";
        public const string PluginName = "PressButtonSpawnMonster";
        public const string PluginVersion = "1.1.0";
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
        public static ConfigEntry<bool> MonsterItem { get; set; }
        public static ConfigEntry<int> spawnHeight { get; set; }

        public void Awake()
        {

            MonsterOne = Config.Bind<string>(
                "Monster 1A (F1)",
                "Monster you want to spawn",
                "Beetle",
                "Monster names can be pulled from the dictionary provided!"
                );
            MonsterTwo = Config.Bind<string>(
                "Monster B (F2)",
                "Monster you want to spawn",
                "Lemurian",
                ""
                );
            MonsterThree = Config.Bind<string>(
                "Monster C (F3)",
                "Monster you want to spawn",
                "BeetleGuard",
                ""
                );
            MonsterFour = Config.Bind<string>(
                "Monster D (F4)",
                "Monster you want to spawn",
                "Wisp",
                ""
                );
            MonsterFive = Config.Bind<string>(
                "Monster E (F5)",
                "Monster you want to spawn",
                "GreaterWisp",
                ""
                );
            MonsterSix = Config.Bind<string>(
                "Monster F (F6)",
                "Monster you want to spawn",
                "LemurianBruiser",
                ""
                );
            MonsterSeven = Config.Bind<string>(
                "Monster G (F7)",
                "Monster you want to spawn",
                "Golem",
                ""
                );
            MonsterEight = Config.Bind<string>(
                "Monster H (F8)",
                "Monster you want to spawn",
                "Nullifier",
                ""
                );
            MonsterNine = Config.Bind<string>(
                "Monster I (F9)",
                "Monster you want to spawn",
                "Scav",
                ""
                );
            MonsterTen = Config.Bind<string>(
                "Monster J (F10)",
                "Monster you want to spawn",
                "Brother",
                ""
                );
            MonsterList = Config.Bind<string>(
                "List of Monsters to spawn",
                "AcidLarva, AncientWispMonster, Beetle, Beetle Guard, Lemurian, LemurianBruiser, BeetleQueen, Bell, Bison, Brother, ClayBoss, ClayBruiser, ClayGrenadier, Clayman FlyingVermin, Golem, GrandParentBoss, Gravekeeper, Wisp, GreaterWisp, Gup, HermitCrab, Imp, ImpBoss, Jellyfish, LunarExploder, LunarGolem, LunarWisp, MagmaWorm, MajorConstruct, MegaConstruct, MiniConstruct, MiniMushroom, Nullifier, Parent, RoboBallBoss, RoboBallMini, Scav, Titan, UrchinTurret Vagrant, Vermin, VoidBarnacle, VoidInfestor, VoidJailer, VoidMegaCrab, Vulture",
                "",
                "Note that VoidBarnacle, VoidJailer, VoidMegaCrab, Vermin, FlyingVermin, ClayGrenadier, and VoidInfestor ONLY work if you have the DLC.  Also note, MajorConstruct and Clayman are unfinished/cut content, and thus may be a bit buggy"
                );
            spawnHeight = Config.Bind<int>(
                "spawn height",
                "adjust to change how far above you the monsters spawn",
                7,
                "ONLY CHANGE if player's height is changed"
                );
            MonsterItem = Config.Bind<bool>(
                "Should the monsters you spawn receive items also?",
                "this could be a bad idea",
                false,
                ""
                );

            Log.Init(Logger);

         
        }

        private void Update()
        {
            Vector3 charPosition = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform.position;
            Vector3 playerPosition = charPosition + new Vector3(0, spawnHeight.Value, 0);

            if (Input.GetKeyDown(KeyCode.F1))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterOne.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient;
                damageBoostCoefficient += Run.instance.difficultyCoefficient;
                //int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);//
                //healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);//
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2)); 
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe);
                }
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterTwo.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);

                }
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterThree.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterFour.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterFive.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterSix.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterSeven.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterEight.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }

            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterNine.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }

            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                CharacterMaster characterMaster = new MasterSummon
                {
                    masterPrefab = MasterCatalog.FindMasterPrefab(MonsterTen.Value + "Master"),
                    position = playerPosition,
                    rotation = base.transform.rotation,
                    summonerBodyObject = null,
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = TeamIndex.Monster,
                }.Perform();
                float healthBoostCoefficient = 1f;
                float damageBoostCoefficient = 1f;
                healthBoostCoefficient += Run.instance.difficultyCoefficient / 1.5f;
                damageBoostCoefficient += Run.instance.difficultyCoefficient / 15f;
                int numberOfPlayers = Mathf.Max(1, Run.instance.livingPlayerCount);
                healthBoostCoefficient *= Mathf.Pow(numberOfPlayers, 0.75f);
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostHp, Mathf.RoundToInt(((healthBoostCoefficient - 1f) * 10) / 2));
                characterMaster.inventory.GiveItem(RoR2Content.Items.BoostDamage, Mathf.RoundToInt(((damageBoostCoefficient - 1f) * 10) / 2));
                if (MonsterItem.Value)
                {
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Hoof, 20);
                    characterMaster.inventory.GiveItem(RoR2Content.Items.Syringe, 10);
                }

            }

        }

    }
}
