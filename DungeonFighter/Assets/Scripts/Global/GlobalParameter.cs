/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，全局参数
 * 
 * Description:
 *      具体作用：
 *      1、定义整个项目的枚举类型
 *      2、定义整个项目的委托
 *      3、定义整个项目的常量
 *      4、定义项目所有的Tag
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class GlobalParameter
    {
        /*定义项目系统常量*/

        public const string JOYSTICK_NAME = "HeroJoystick";            //EasyTouch摇杆名称，这里为EasyTouch对象上的组件的名称

        //输入管理器定义
        public const string INPUT_MGR_ATTACKNAME_NORMAL = "NormalAttack";           //普攻
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICKA = "MagicTrickA";       //技能A
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICKB = "MagicTrickB";       //技能B
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICKC = "MagicTrickC";       //技能C
        public const string INPUT_MGR_ATTACKNAME_MAGICTRICKD = "MagicTrickD";       //技能D

        //各种间隔时间
        public const float INTERVAL_TIME_0 = 0f;
        public const float INTERVAL_TIME_0DOT02 = 0.02f;
        public const float INTERVAL_TIME_0DOT1 = 0.1f;
        public const float INTERVAL_TIME_0DOT2 = 0.2f;
        public const float INTERVAL_TIME_0DOT3 = 0.3f;  
        public const float INTERVAL_TIME_0DOT5 = 0.5f;  
        public const float INTERVAL_TIME_1 = 1f;  
        public const float INTERVAL_TIME_1DOT5 = 1.5f;  
        public const float INTERVAL_TIME_2 = 2f;  
        public const float INTERVAL_TIME_2DOT5 = 2.5f;
        public const float INTERVAL_TIME_3 = 3f;
        public const float INTERVAL_TIME_5 = 5f;  
    }
    public class Tag
    {
        public static string Enemy = "Enemy";
        public static string Player = "Player";
        public static string MajorCity_Up = "MajorCity_Up";
        public static string MajorCity_Down = "MajorCity_Down";
        public static string PackageItems = "PackageItems";
        public static string UICamera = "UICamera";
        public static string UIPlayerInfo = "UI_PlayerInfo";
        
    }
#region 枚举定义

    public enum e_CurrentGameType
    {
        None,
        NewGame,                                    //新的游戏         
        Continue,                                   //继续游戏
    }

    /// <summary>
    /// 场景名称
    /// </summary>
    public enum e_ScenesEnum
    {
        StartScene,
        LoadingScene,                                               
        LoginScene,
        MajorCity,
        Level1,
        Level2,
        BaseScene,
        TestScene,
    }
    /// <summary>
    /// 玩家职业类型
    /// </summary>
    public enum e_PlayerType
    {
        SwordHero,                                  //剑士
        MagicHero,                                  //魔法师
        Other,                                      //其他
    }
    /// <summary>
    /// 玩家动画类型
    /// </summary>
    public enum e_HeroActionState
    {
        None,                                       //无
        Idle,                                       //休闲
        Running,                                    //跑动
        NormalAttack,                               //普攻
        MagicTrickA,                                //技能A
        MagicTrickB,                                //技能B
    }
    /// <summary>
    /// 普攻连招
    /// </summary>
    public enum e_NormalATKComboState
    {
        NormalATK1,
        NormalATK2,
        NormalATK3,
    }
    /// <summary>
    /// 等级名称
    /// </summary>
    public enum e_LevelName
    {
        Level_0 = 0,
        Level_1 = 1,
        Level_2 = 2,
        Level_3 = 3,
        Level_4 = 4,
        Level_5 = 5,
        Level_6 = 6,
        Level_7 = 7,
        Level_8 = 8,
        Level_9 = 9,
        Level_10 = 10,
    }

    /// <summary>
    /// 敌人状态
    /// </summary>
    public enum e_EnemyState
    {
        Idle,                                       //休闲
        Walking,                                    //行走
        Attack,                                     //攻击
        Hurt,                                       //受伤
        Death,                                      //死亡
    }
#endregion 

#region 委托定义
    /// <summary>
    /// 委托：主角控制
    /// </summary>
    /// <param name="控制类型"></param>
    public delegate void del_PlayerControlWithStr(string _controlType);

    /// <summary>
    /// 委托：玩家核心模型数值
    /// </summary>
    /// <param name="_kv"></param>
    public delegate void del_PlayerKernalModel(KeyValueUpdate _kv);

    public class KeyValueUpdate
    {
        private string _key;
        private float _value;

        #region 属性
        public string Key
        {
            get { return _key; }
        }
        public float Value
        {
            get { return _value; }
        }
        #endregion

        public KeyValueUpdate(string _key, float _value)
        {
            this._key = _key;
            this._value = _value;
        }
    }

#endregion
}