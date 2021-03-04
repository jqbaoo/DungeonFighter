/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，全局参数管理器
 * 
 * Description:
 *      具体作用：
 *      1、跨场景全局数值传递
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
    public static class GlobalParaMgr
    {
        //下一场景的名称
        public static e_ScenesEnum NextScenesName = e_ScenesEnum.LoginScene;
        //玩家姓名
        public static string PlayerName = "";
        //玩家类型
        public static e_PlayerType PlayerTypes = e_PlayerType.SwordHero;
        //游戏类型(开始/继续)
        public static e_CurrentGameType CurrentGameType = e_CurrentGameType.NewGame;
    }
}
