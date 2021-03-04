/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，第二关卡场景控制处理
 * 
 * Description:
 *      具体作用：
 *      1、控制敌人的出生
 *      2、播放背景音乐
 *      3、对某些较远的区域进行隐藏，提升性能
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;
using Model;

namespace Control
{
    public class Ctrl_Level2Scene : BaseControl
    {
        public static Ctrl_Level2Scene Instance;

        public Transform traHeroSpawnPos;

        //背景音乐与音效
        public AudioClip ac_BackgroundMusic;                                        //背景音乐
        public AudioClip ac_BackgroundByFighting;                                   //BOSS战斗音效

        //标签：需要隐藏的对象
        public string[] tagNameByHideObject;
        /* 敌人预设 */
        public GameObject goArcher;
        public GameObject goWarrior;
        public GameObject goMagic;
        public GameObject goKing;
        public GameObject goBoss;
        /* 敌人产生地点 */
        //区域A
        public Transform[] traSpawnEnemyPos_AreaA_Archer;
        public Transform[] traSpawnEnemyPos_AreaA_Warrior;
        //区域B
        public Transform[] traSpawnEnemyPos_AreaB_Archer;
        public Transform[] traSpawnEnemyPos_AreaB_Warrior;
        public Transform[] traSpawnEnemyPos_AreaB_King;
        //区域C
        public Transform[] traSpawnEnemyPos_AreaC_King;
        //区域D (Boss核心战斗区域)
        public Transform[] traSpawnEnemyPos_AreaBoss_Archer;
        public Transform[] traSpawnEnemyPos_AreaBoss_Warrior;
        public Transform[] traSpawnEnemyPos_AreaBoss_King;
        public Transform[] traSpawnEnemyPos_AreaBoss_Boss;

        //粒子墙
        public GameObject goParticleWall;                                           //BOSS战斗粒子墙
        /* 敌人的单次出生控制 */
        private bool _isSingleSpawn_AreaA = true;
        private bool _isSingleSpawn_AreaB = true;
        private bool _isSingleSpawn_AreaC = true;
        private bool _isSingleSpawnBoss = true;
        private Ctrl_BaseEnemyProperty _bossProperty;


        void Awake()
        {
            Instance = this;
            //敌人出生触发器
            TriggerCommonEvent.event_CommonTrigger += SpawnEnemy;
        }

        void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(0.7f);
            //播放背景音乐
            AudioManager.PlayBackground(ac_BackgroundMusic);
            //默认隐藏场景中非活动的区域
            //StartCoroutine("HideUnactiveArea");
            //默认关闭BOSS粒子墙
            goParticleWall.SetActive(false);

            GameObject tmp_GoHero = ResourcesManager.GetInstance().LoadResource("Prefabs/Player/SwordAnimatorHero", true);
            tmp_GoHero.transform.position = traHeroSpawnPos.position;

        }


        public void ReturnMajorCity()
        {
            //保存数据
            StartCoroutine("SaveData");
            //返回主城
            StartCoroutine("EnterMajorCity");
        }
        IEnumerator SaveData()
        {
            //Debug.Log("SaveData");

            SaveAndLoading.GetInstance().SaveGameProcess();
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
        }
        IEnumerator EnterMajorCity()
        {
            //读取单机进度
            SaveAndLoading.GetInstance().LoadingGame_GlobalParameter();
            SaveAndLoading.GetInstance().LoadingGame_PlayerData();
            //Debug.Log("EnterMajorCity");
            yield return new WaitForSeconds(2f);
            base.EnterNextScene(e_ScenesEnum.MajorCity);
        }

        /// <summary>
        /// 动态产生敌人
        /// </summary>
        /// <param name="_CTT"></param>
        private void SpawnEnemy(e_CommonTriggerType _CTT)
        {
            switch (_CTT)
            {
                case e_CommonTriggerType.None:
                    break;
                case e_CommonTriggerType.Enemy1_Dialog:
                    if (_isSingleSpawn_AreaA)
                    {
                        _isSingleSpawn_AreaA = false;
                        //A区域动态加载敌人
                        SpawnEnemy_AtArea_A();
                    }
                    break;
                case e_CommonTriggerType.Enemy2_Dialog:
                    if (_isSingleSpawn_AreaB)
                    {
                        _isSingleSpawn_AreaB = false;
                        //B区域动态加载敌人
                        SpawnEnemy_AtArea_B();
                    }
                    break;
                case e_CommonTriggerType.Enemy3_Dialog:
                    if (_isSingleSpawn_AreaC)
                    {
                        _isSingleSpawn_AreaC = false;
                        //C区域动态加载敌人
                        SpawnEnemy_AtArea_C();
                    }
                    break;
                case e_CommonTriggerType.Enemy4_Dialog:
                    if (_isSingleSpawnBoss)
                    {
                        //显示粒子墙
                        _isSingleSpawnBoss = false;
                        DisplayParticleWall();
                        StartCoroutine("SpawnEnemy_AtAreaBoss");
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 隐藏非活动的区域
        /// </summary>
        /// <returns></returns>
        IEnumerator HideUnactiveArea()
        {
            yield return new WaitForEndOfFrame();
            foreach (string tmp_TagNameItem in tagNameByHideObject)
            {
                GameObject[] tmp_GoHideObjArray = GameObject.FindGameObjectsWithTag(tmp_TagNameItem);
                foreach (GameObject tmp_GoHideObjItem in tmp_GoHideObjArray)
                {
                    tmp_GoHideObjItem.SetActive(false);
                }
            }
        }

        #region 产生敌人
        /// <summary>
        /// A区域的敌人产生
        /// </summary>
        private void SpawnEnemy_AtArea_A()
        {

            //生成敌人
            if (goArcher != null)
            {
                StartCoroutine(base.SpawnEnemy(goArcher, 4, traSpawnEnemyPos_AreaA_Archer));
            }
            if (goWarrior != null)
            {
                StartCoroutine(base.SpawnEnemy(goWarrior, 4, traSpawnEnemyPos_AreaA_Warrior));
            }
        }

        /// <summary>
        /// B区域的敌人产生
        /// </summary>
        private void SpawnEnemy_AtArea_B()
        {
            if (goArcher)
            {
                StartCoroutine(base.SpawnEnemy(goArcher, 3, traSpawnEnemyPos_AreaB_Archer));
            }
            if (goWarrior)
            {
                StartCoroutine(base.SpawnEnemy(goWarrior, 3, traSpawnEnemyPos_AreaB_Warrior));
            }
            if (goKing)
            {
                StartCoroutine(base.SpawnEnemy(goKing, 1, traSpawnEnemyPos_AreaB_King, true, 0.75f));
            }
        }


        /// <summary>
        /// C区域的敌人产生
        /// </summary>
        private void SpawnEnemy_AtArea_C()
        {
            if (goKing)
            {
                StartCoroutine(base.SpawnEnemy(goKing, 3, traSpawnEnemyPos_AreaC_King, true, 0.75f));
            }
        }

        /// <summary>
        /// BOSS区域的敌人产生
        /// </summary>
        /// <returns></returns>
        IEnumerator SpawnEnemy_AtAreaBoss()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
            StartCoroutine(base.SpawnEnemy(goBoss, 1, traSpawnEnemyPos_AreaBoss_Boss, true, 2));

            //循环产生更多的敌人
            while (true)
            {
                yield return new WaitForSeconds(10f);
                //如果所有敌人数量小于等于5个，则产生新的一批敌人
                if (CountEnemyNumberAtBossArea() <= 5)
                {
                    yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                    StartCoroutine(base.SpawnEnemy(goKing, 1, traSpawnEnemyPos_AreaBoss_King, true, 0.75f));
                    StartCoroutine(base.SpawnEnemy(goArcher, 2, traSpawnEnemyPos_AreaBoss_Archer, true));
                    StartCoroutine(base.SpawnEnemy(goWarrior, 3, traSpawnEnemyPos_AreaBoss_Warrior, true));
                }
            }
        }
        #endregion

        /// <summary>
        /// 进入BOSS区域显示粒子墙，阻止玩家离开
        /// </summary>
        private void DisplayParticleWall()
        {
            //开启粒子墙，阻止玩家离开
            goParticleWall.SetActive(true);
            //更新背景音乐
            AudioManager.PlayBackground(ac_BackgroundByFighting);
        }

        ///// <summary>
        ///// 持续检查BOSS是否死亡，死亡则在5秒后自动转回场景
        ///// </summary>
        ///// <returns></returns>
        //IEnumerator CheckBossLift()
        //{
        //    yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT1);
        //    while (true)
        //    {
        //        yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
        //        Debug.Log(_bossProperty.isDeath);
        //        if (_bossProperty.isDeath)
        //        {
        //            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
        //            goUI_Level2Scene.SetActive(true);
        //        }
        //    }
        //}

        /// <summary>
        /// 通过标签查找统计场景中所有敌人的数量
        /// </summary>
        /// <returns></returns>
        private int CountEnemyNumberAtBossArea()
        {
            GameObject[] tmp_GoEnemyArray = GameObject.FindGameObjectsWithTag(Tag.Enemy);
            if (tmp_GoEnemyArray != null)
            {
                return tmp_GoEnemyArray.Length;
            }
            else
            {
                return 0;
            }
        }

    }//class end
}