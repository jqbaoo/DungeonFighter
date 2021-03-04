/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，开始场景
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
using Control;
using Kernal;
using UnityEngine.UI;

namespace View
{
    public class View_StartScene : MonoBehaviour
    {
        public Button btn_NewGame;
        public Button btn_Continue;
        void Awake()
        {
            btn_NewGame = GameTool.GetChildComponent<Button>(transform.parent.gameObject, "Btn_NewGame");
            btn_Continue = GameTool.GetChildComponent<Button>(transform.parent.gameObject, "Btn_Continue");
        }

        void Start()
        {
            btn_NewGame.onClick.AddListener(ClickNewGame);
            btn_Continue.onClick.AddListener(ClickGameContinue);
        }
        /// <summary>
        /// 新的游戏
        /// </summary>
        public void ClickNewGame()
        {
            Ctrl_StartScene.Instance.ClickNewGame();
        }
        /// <summary>
        /// 继续游戏
        /// </summary>
        public void ClickGameContinue()
        {
            //调用控制层的"继续游戏"方法
            Ctrl_StartScene.Instance.ClickGameContinue();
        }
    }
}