/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层：枚举转换字符串
 * 
 * Description:
 *      具体作用：
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
    public class ConvertEnumToStr
    {
        private static ConvertEnumToStr _Instance;
        private Dictionary<e_ScenesEnum, string> _dicSceneEnumLib;            //枚举场景类型集合
        private ConvertEnumToStr()
        {
            _dicSceneEnumLib = new Dictionary<e_ScenesEnum, string>();
            _dicSceneEnumLib.Add(e_ScenesEnum.StartScene, "1_StartScene");
            _dicSceneEnumLib.Add(e_ScenesEnum.LoginScene, "2_LoginScene");
            _dicSceneEnumLib.Add(e_ScenesEnum.LoadingScene, "LoadingScene");
            _dicSceneEnumLib.Add(e_ScenesEnum.MajorCity, "4_MajorCity");
            _dicSceneEnumLib.Add(e_ScenesEnum.Level1, "3_Level1");
            _dicSceneEnumLib.Add(e_ScenesEnum.Level2, "5_Level2");
            _dicSceneEnumLib.Add(e_ScenesEnum.TestScene, "100_TestDialogsScene");
            //_dicSceneEnumLib.Add(e_ScenesEnum.BaseScene, "1_StartScene");
        }

        public static ConvertEnumToStr GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new ConvertEnumToStr();
            }
            return _Instance;
        }
        /// <summary>
        /// 得到字符串形式的场景名称
        /// </summary>
        /// <param name="枚举类型的场景名称"></param>
        /// <returns></returns>
        public string GetSrtByEnumScene(e_ScenesEnum _sceneEnum)
        {
            if (_dicSceneEnumLib != null && _dicSceneEnumLib.Count >= 1)
            {
                return _dicSceneEnumLib[_sceneEnum];
            }
            else
            {
                Debug.LogWarning(GetType() + "/GetSrtByEnumScene()/_dicSceneEnumLib<=0!");
                return null;
            }
        }
    }
}