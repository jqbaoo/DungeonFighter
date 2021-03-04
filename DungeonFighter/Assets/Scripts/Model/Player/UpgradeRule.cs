/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，升级规则
 * 
 * Description:
 *      具体作用：描述项目中的"升级"规则
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

namespace Model
{
    public class UpgradeRule
    {
        private static UpgradeRule _instance;

        private UpgradeRule()
        {

        }

        public static UpgradeRule GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UpgradeRule();
            }
            return _instance;
        }

        /// <summary>
        /// 等级升级条件
        /// </summary>
        /// <param name="_experience">经验数值</param>
        public void GetUpgradeCondition(int _experience)
        {
            Debug.Log("等级升级条件");
            int tmp_CurrentLevel = Model_PlayerExtenalDataProxy.GetInstance().GetLevel();

            if (_experience >= 100 && tmp_CurrentLevel == 1)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
            else if (_experience >= 300 && tmp_CurrentLevel == 2)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
            else if (_experience >= 500 && tmp_CurrentLevel == 3)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
            else if (_experience >= 1000 &&  tmp_CurrentLevel == 4)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
            else if (_experience >= 3000 && tmp_CurrentLevel == 5)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
            else if (_experience >= 5000 && tmp_CurrentLevel == 6)
            {
                Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
            }
        }

        /// <summary>
        /// 升级后需要处理的内容
        /// 1、增加所有核心数值上限
        /// 2、所有核心数值回满
        /// </summary>
        public void UpgradeOperation(e_LevelName _e_LevelName)
        {
            switch (_e_LevelName)
            {
                
                case e_LevelName.Level_0:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_1:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_2:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_3:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_4:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_5:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_6:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_7:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_8:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_9:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case e_LevelName.Level_10:
                    UpgradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                default:
                    break;
            }
        }//UpgradeOperation end

        /// <summary>
        /// 具体升级规则
        /// </summary>
        /// <param name="_hp">最大生命值增量</param>
        /// <param name="_mp">最大魔法值增量</param>
        /// <param name="_atk">最大攻击力增量</param>
        /// <param name="_def">最大防御力增量</param>
        /// <param name="_dex">最大敏捷增量</param>
        private void UpgradeRuleOperation(float _hp, float _mp, float _atk, float _def, float _dex)
        {
            //增加上限
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(_hp);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(_mp);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxATK(_atk);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEF(_def);
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMaxDEX(_dex);
            //状态回满
            Model_PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(Model_PlayerKernalDataProxy.GetInstance().GetMaxHealth());
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(Model_PlayerKernalDataProxy.GetInstance().GetMaxMagic());
        }
    }
}