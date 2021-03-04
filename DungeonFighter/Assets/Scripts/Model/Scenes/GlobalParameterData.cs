/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，全局参数数据
 * 
 * Description:
 *      具体作用：用于做"对象持久化"服务。
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
    public class GlobalParameterData
    {
        //下一个场景名称
        private e_ScenesEnum _nextScenesName;
        //玩家的姓名
        private string _playerName;

        #region 属性
        public e_ScenesEnum NextScenesName
        {
            get { return _nextScenesName; }
            set { _nextScenesName = value; }
        }

        public string PlayerName
        {
            get { return _playerName; }
            set { _playerName = value; }
        }
        #endregion

        private GlobalParameterData() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_scenesName">场景名称</param>
        /// <param name="_playerName">玩家姓名</param>
        public GlobalParameterData(e_ScenesEnum _scenesName, string _playerName)
        {
            this._nextScenesName = _scenesName;
            this._playerName = _playerName;
        }
    }
}