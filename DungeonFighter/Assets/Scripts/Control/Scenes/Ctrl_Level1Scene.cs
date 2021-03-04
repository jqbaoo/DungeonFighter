/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，第一关卡场景控制处理
 * 
 * Description:
 *      具体作用：
 *      1、负责第一关卡敌人的动态加载
 *      2、敌人的多个出生点的设置
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
    public class Ctrl_Level1Scene : BaseControl
    {
        public AudioClip acBackground;                                              //背景音乐        

        public Transform[] traSpawnEnemyPos;                                        //敌人产生的位置

        public GameObject goWarriorPrefab_Green;                                    //绿色战士预制体
  

        private bool _isSingleTime = true;
        void Awake()
        {
            //Model_PlayerExtenalData.event_PlayerExtenalData += LevelUp;
        }
        IEnumerator Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.3f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(acBackground);

            StartCoroutine(SpawnEnemy(2));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpawnEnemy(3));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpawnEnemy(5));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpawnEnemy(3));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            StartCoroutine(SpawnEnemy(4));
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
        }

        /// <summary>
        /// 生成敌人(使用缓存)
        /// </summary>
        /// <param name="_createEnemyNum">生成的数量</param>
        /// <returns></returns>
        IEnumerator SpawnEnemy(int _createEnemyNum)
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            for (int i = 0; i < _createEnemyNum; i++)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                //随机获得出生点
                Transform tmp_TranEnemySpawnPos = GetRandomEnemySpawnPos();
                //克隆位置
                goWarriorPrefab_Green.transform.position = new Vector3(tmp_TranEnemySpawnPos.position.x, tmp_TranEnemySpawnPos.position.y, tmp_TranEnemySpawnPos.position.z);
                //在对象池中取出对象
                PoolManager.PoolsArray["Enemies"].GetGameObjectByPool(goWarriorPrefab_Green, goWarriorPrefab_Green.transform.position, Quaternion.identity);

            }
        }

        /// <summary>
        /// 随机得到敌人的出生点
        /// </summary>
        /// <returns></returns>
        private Transform GetRandomEnemySpawnPos()
        {
            int tmp_RandomNum = UnityHelper.GetInstance().GetRandomNum(1, traSpawnEnemyPos.Length);
            return traSpawnEnemyPos[tmp_RandomNum - 1];
        }

        /// <summary>
        /// 得到敌人种类的路径
        /// </summary>
        /// <returns></returns>
        private string GetRandomEnemyType()
        {
            string tmp_EnemyPath = "Prefabs/Enemies/skeleton_warrior_green";
            int tmp_RandomNum = UnityHelper.GetInstance().GetRandomNum(1, 2);
            if (tmp_RandomNum == 1)
            {
                tmp_EnemyPath = "Prefabs/Enemies/skeleton_warrior_green";
            }
            else if (tmp_RandomNum == 2)
            {
                tmp_EnemyPath = "Prefabs/Enemies/skeleton_warrior_red";
            }
            return tmp_EnemyPath;
        }

        /// <summary>
        /// 敌人出现的粒子特效
        /// </summary>
        private void EnemySpawnParticalEffect(GameObject _enemyWarrior)
        {
            StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/EnemyDisplay", true, _enemyWarrior.transform.position, transform.rotation, _enemyWarrior.transform, "EnemyDisplayEffect", 0));
        }

        /// <summary>
        /// 主角升级
        /// </summary>
        private void LevelUp(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Level"))
            {
                if (_isSingleTime)
                {
                    _isSingleTime = false;
                }
                else
                {
                    HeroLevelUp();
                }
            }
        }

        private void HeroLevelUp()
        {
            ResourcesManager.GetInstance().LoadResource("ParticleProps/Hero_Levelup", true);
            AudioManager.PlayAudioEffectA("LevelUpD");
        }
    }
}