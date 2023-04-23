﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    public class DlgBattleAwakeSystem : AwakeSystem<DlgBattle>
    {
        protected override void Awake(DlgBattle self)
        {
            self.Awake();
        }
    }
    public class DlgBattleUpdateSystem : UpdateSystem<DlgBattle>
    {
        protected override void Update(DlgBattle self)
        {
            // if (Time.frameCount % 3 == 0)
                // self.Tick();

            self.Update();
        }
    }

    public class DlgBattleDestroySystem : DestroySystem<DlgBattle>
    {
        protected override void Destroy(DlgBattle self)
        {
            
        }
    }

    [FriendOf(typeof(DlgBattle))]
	public static  class DlgBattleSystem
	{
        public static void Awake(this DlgBattle self)
        {
            self.RefreshSkillView();
        }

        public static void RefreshSkillView(this DlgBattle self)
        {
            //刷新技能显示
            self.MyUnit = UnitHelper.GetMyUnitFromCurrentScene(self.DomainScene().CurrentScene());
            Skill skill1 = null;
            if (self.MyUnit.GetComponent<BattleUnitComponent>().TryGetSkill(ESkillAbstractType.ActiveSkill, 0, out skill1))
            {
                self.Skill1 = skill1;
                self.InitSkill(self.Skill1, self.View.EIconSkill1Image);
            }
            Skill skill2 = null;
            if (self.MyUnit.GetComponent<BattleUnitComponent>().TryGetSkill(ESkillAbstractType.ActiveSkill, 0, out skill2))
            {
                self.Skill2 = skill2;
                self.InitSkill(self.Skill2, self.View.EIconSkill2Image);
            }
        }
        private static void InitSkill(this DlgBattle self, Skill skill, Image imgIcon)
        {
            if (skill == null)
                return;
            //初始化设置技能icon等数据
        }
        
        public static void RegisterUIEvent(this DlgBattle self)
        {
            self.View.E_JoystickJoystick.OnValueChanged.AddListener(self.OnPressJoystick);
            // self.View.E_JoystickJoystick.OnSwipeEvent.AddListener(self.OnSwipeJoystick);
            self.View.EBtnSkill1Button.AddListener(self.OnClickSkill1);
            self.View.EBtnSkill2Button.AddListener(self.OnClickSkill2);

        }

		public static void ShowWindow(this DlgBattle self, ShowWindowDataBase contextData = null)
		{
            
		}


        public static void OnPressJoystick(this DlgBattle self, Vector2 v)
        {
            if(v == Vector2.zero)
                return;
            self.DomainScene().GetComponent<OperaComponent>().OnMove(v);

        }
        
        private static void OnClickSkill1(this DlgBattle self)
        {
            
        }
        private static void OnClickSkill2(this DlgBattle self)
        {
            
        }

        public static void Update(this DlgBattle self)
        {
            
        }
    }
}
