/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 测试，测试对话系统
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
using Global;
using Kernal;

namespace Test
{
    public class Test_DialogsUI : MonoBehaviour
    {
        void Start()
        {
            DialogUIManager.Instance.DisplayNextDialog(e_DialogType.DoubleDialogs, 1);
        }
        public void DisplayNextDialogInfo()
        {
            bool tmp_Result = DialogUIManager.Instance.DisplayNextDialog(e_DialogType.DoubleDialogs, 1);
            if (tmp_Result)
            {
                //Log.Write(GetType() + "/DisplayNextDialogInfo()/对话结束");
            }
            else
            {
                //Log.SyncLogArrayToFile();
            }
        }
    }
}