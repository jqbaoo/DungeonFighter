/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角攻击
 * 
 * Description:
 *      开发思路：
 *      1、把附近的所有敌人放入"敌人数组"。
 *          1.1 得到所有敌人，放入"敌人数组"。
 *          1.2 判断"敌人集合"，找出最近的敌人。
 *          
 *      2、玩家在一定范围内，开始自动注视最近的敌人。
 *      
 *      3、攻击，对玩家"正面"的敌人给予一定的伤害处理。
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

namespace Control
{
    public class Ctrl_HeroAttack : BaseControl
    {
        public float floMinAttackDistance = 4f;                     //最小攻击距离(关注情况下)
        public float floHeroRotateSpeed = 1f;                       //转身速率
        public float floRealAttackArea = 2f;                        //有效攻击距离
        //技能参数定义
        public float floAttackAreaByMagicA = 4f;                    //技能A的攻击范围
        public float floAttackAreaByMagicB = 8f;                    //技能B的攻击范围
        public int intAttackPowerMultipleByMagicA = 5;              //技能A的攻击力倍率
        public int intAttackPowerMultipleByMagicB = 20;             //技能B的攻击力倍率

        private List<GameObject> _list_Enemies;                     //敌人集合
        private Transform _tran_NearestEnemy;                       //最近敌人的位置
        private float _floMaxDistance = 10f;                        //玩家关注的最大距离




        void Awake()
        {
            //事件注册
            #if UNITY_STANDALONE_WIN || UNITY_ENDITOR
            Ctrl_HeroAttackInputByKey.event_PlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByKey.event_PlayerControl += ResponseMagicTrickA;
            Ctrl_HeroAttackInputByKey.event_PlayerControl += ResponseMagicTrickB;
            #endif

            #if UNITY_ANDROID || UNITY_IPHONE
            Ctrl_HeroAttackInputByET.event_PlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByET.event_PlayerControl += ResponseMagicTrickA;
            Ctrl_HeroAttackInputByET.event_PlayerControl += ResponseMagicTrickB;
            #endif
        }
        void Start()
        {
            _list_Enemies = new List<GameObject>();

            StartCoroutine("RecordNearByEnemiesToArray");

            StartCoroutine("HeroRotationEnemy");
        }

        /// <summary>
        /// 把附近所有敌人放入"敌人数组"
        /// </summary>
        IEnumerator RecordNearByEnemiesToArray()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);

                //1.1 得到所有敌人，放入"敌人数组"。
                GetEnemiesToArray();
                //1.2 判断"敌人集合"，找出最近的敌人。
                GetNearestEnemy();
            }
        }

        /// <summary>
        /// 得到所有存活的敌人
        /// </summary>
        private void GetEnemiesToArray()
        {
            _list_Enemies.Clear();
            GameObject[] tmp_GoEnemies = GameObject.FindGameObjectsWithTag(Tag.Enemy);
            foreach (GameObject tmp_GoEnemyItem in tmp_GoEnemies)
            {
                //判断敌人是否存活
                Ctrl_BaseEnemyProperty tmp_Enemy = tmp_GoEnemyItem.GetComponent<Ctrl_BaseEnemyProperty>();

                if (tmp_Enemy && tmp_Enemy.CurrentState != e_EnemyState.Death)
                {
                    _list_Enemies.Add(tmp_GoEnemyItem);
                }
            }
        }
        /// <summary>
        /// 得到最近的敌人
        /// </summary>
        private void GetNearestEnemy()
        {
            if ((_list_Enemies != null) && (_list_Enemies.Count >= 1))
            {
                foreach (GameObject tmp_GoEnemy in _list_Enemies)
                {
                    float tmp_floDistance = Vector3.Distance(this.transform.position, tmp_GoEnemy.transform.position);
                    if (tmp_floDistance < _floMaxDistance)
                    {
                        _floMaxDistance = tmp_floDistance;
                        //获取最近的敌人
                        _tran_NearestEnemy = tmp_GoEnemy.transform;
                    }
                }
            }
        }

        IEnumerator HeroRotationEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT2);             //////TODO完善攻击不敏感问题  在于攻击的时候协程不一定都能每帧检测，看看能不能放到Update上，或者降低间隔时间
                if (_tran_NearestEnemy != null && Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Idle)
                {
                    float tmp_floDistance = Vector3.Distance(this.transform.position, _tran_NearestEnemy.position);
                    if (tmp_floDistance < floMinAttackDistance)
                    {
                        //使用向量减法进行旋转
                        UnityHelper.GetInstance().FaceToGo(this.transform, _tran_NearestEnemy, floHeroRotateSpeed);
                    }
                }
            }
        }

        /// <summary>
        /// 攻击_普攻
        /// </summary>
        private void AttackEnemyByNormal()
        {
            base.AttackEnemy(_list_Enemies, _tran_NearestEnemy, floRealAttackArea, 1, true);
        }

        /// <summary>
        /// 技能A
        /// 主角周围特定范围内造成伤害
        /// </summary>
        IEnumerator AttackEnemyByMagicA()
        {

            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);

            base.AttackEnemy(_list_Enemies, _tran_NearestEnemy, floAttackAreaByMagicA, intAttackPowerMultipleByMagicA, false);
        }

        /// <summary>
        /// 技能B
        /// 主角前方特定范围内造成伤害
        /// </summary>
        IEnumerator AttackEnemyByMagicB()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
            base.AttackEnemy(_list_Enemies, _tran_NearestEnemy, floAttackAreaByMagicB, intAttackPowerMultipleByMagicB, true);
        }

        #region 相应攻击输入
        /// <summary>
        /// 响应攻击
        /// </summary>
        public void ResponseNormalAttack(string _controlType)
        {
            if (_controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_NORMAL)
            {
                //Debug.Log("普攻攻击");
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.NormalAttack);
                //给特定敌人伤害处理
                AttackEnemyByNormal();
                
            }
        }

        /// <summary>
        /// 响应技能A
        /// </summary>
        public void ResponseMagicTrickA(string _controlType)
        {
            if (_controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKA)
            {
                //Debug.Log("A技能攻击");
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.MagicTrickA);
                //给特定敌人伤害处理
                //StartCoroutine("AttackEnemyByMagicA");
                base.AttackEnemy(_list_Enemies, _tran_NearestEnemy, floAttackAreaByMagicA, intAttackPowerMultipleByMagicA, false);
            }
        }

        /// <summary>
        /// 响应技能B
        /// </summary>
        public void ResponseMagicTrickB(string _controlType)
        {
            if (_controlType == GlobalParameter.INPUT_MGR_ATTACKNAME_MAGICTRICKB)
            {
                //Debug.Log("B技能攻击");
                //播放攻击动画
                Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.MagicTrickB);
                //给特定敌人伤害处理
                //StartCoroutine("AttackEnemyByMagicB");
                base.AttackEnemy(_list_Enemies, _tran_NearestEnemy, floAttackAreaByMagicB, intAttackPowerMultipleByMagicB, true);
            }
        }
        #endregion


    }//class end
}