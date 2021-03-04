/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，敌人(战士)的属性
 * 
 * Description:
 *      具体作用：
 *      1、生命值、攻击力、防御力、是否存活、当前状态
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
    public class Ctrl_WarriorGreen_Property : Ctrl_BaseEnemyProperty
    {
        public int intHeroExperience = 2000;                              //杀敌经验值
        public int intMaxHealth = 1000;                                   //最大生命值
        public int intATK = 2;                                          //攻击力
        public int intDEF = 2;                                          //防御力

        void Start()
        {
            base.HeroExperience = intHeroExperience;
            base.MaxHealth = intMaxHealth;
            base.ATK = intATK;
            base.DEF = intDEF;
            base.RunMethodInChild();
        }
    }
}