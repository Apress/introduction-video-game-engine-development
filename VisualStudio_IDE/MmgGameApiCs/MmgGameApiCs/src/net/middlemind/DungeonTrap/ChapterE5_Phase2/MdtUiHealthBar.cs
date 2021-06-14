using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// A class that represents a UI element, the health bar.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/22/2020
    /// </summary>
    public class MdtUiHealthBar : MdtBase
    {
        /// <summary>
        /// The subject of this UI element.
        /// </summary>
        public MmgBmp subj = null;

        /// <summary>
        /// The background subject of this UI element.
        /// </summary>
        public MmgBmp subjBack = null;

        /// <summary>
        /// A bool flag indicating if the associated character is dead.
        /// </summary>
        public bool isDead = false;

        /// <summary>
        /// The maximum health value.
        /// </summary>
        public int healthMax = 4;

        /// <summary>
        /// The current health value.
        /// </summary>
        public int healthCurrent = 4;

        /// <summary>
        /// A private variable used in internal methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// The screen this UI element belongs to.
        /// </summary>
        public ScreenGame screen = null;

        /// <summary>
        /// The player type this UI health bar is associated with.
        /// </summary>
        public MdtPlayerType player = MdtPlayerType.NONE;

        /// <summary>
        /// The color of the UI health bar.
        /// </summary>
        public MmgColor backColor = null;

        /// <summary>
        /// A base constructor that takes no arguments and loads object resources automatically.
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="Screen"></param>
        /// <param name="BackColor"></param>
        public MdtUiHealthBar(MdtPlayerType Player, ScreenGame Screen, MmgColor BackColor)
        {
            SetSubj(MmgHelper.GetBasicCachedBmp("health_ui_lg.png"));
            SetMdtType(MdtObjType.UI);
            SetMdtSubType(MdtObjSubType.UI_HEALTH_BAR);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
            SetPlayer(Player);
            SetScreen(Screen);
            SetBackColor(BackColor);
            SetSubjBack(MmgHelper.CreateFilledBmp((int)(subj.GetWidth() * 0.80) - 2, (int)(subj.GetHeight() * 0.90), BackColor));
            SetCurrentHealth(healthMax);
        }

        /// <summary>
        /// A constructor that allows you to specify the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject image for this UI health bar.</param>
        /// <param name="Player">The player type this UI health bar is associated with.</param>
        /// <param name="Screen">The ScreenGame object this health bar belongs to.</param>
        /// <param name="BackColor">The background color used to fill in the health bar.</param>
        public MdtUiHealthBar(MmgBmp Subj, MdtPlayerType Player, ScreenGame Screen, MmgColor BackColor)
        {
            SetSubj(Subj);
            SetMdtType(MdtObjType.UI);
            SetMdtSubType(MdtObjSubType.UI_HEALTH_BAR);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
            SetPlayer(Player);
            SetScreen(Screen);
            SetBackColor(BackColor);
            SetSubjBack(MmgHelper.CreateFilledBmp((int)(subj.GetWidth() * 0.80) - 2, (int)(subj.GetHeight() * 0.90), BackColor));
            SetCurrentHealth(healthMax);
        }

        /// <summary>
        /// A method that marks damage on the UI health bar.
        /// </summary>
        /// <param name="i">The amount of damage to register.</param>
        public void TakeDamage(int i)
        {
            healthCurrent -= i;
            if (healthCurrent < 0)
            {
                healthCurrent = 0;
            }
            SetCurrentHealth(healthCurrent);
        }

        /// <summary>
        /// Resets the UI health bar health to full.
        /// </summary>
        public void RestoreAllHealth()
        {
            SetCurrentHealth(healthMax);
        }

        /// <summary>
        /// Sets the current health bar value.
        /// </summary>
        /// <param name="i">The health value to set the UI health bar to.</param>
        public void SetCurrentHealth(int i)
        {
            if (i <= 0)
            {
                //player is dead
                SetSubjBack(MmgHelper.CreateFilledBmp(1, (int)(subj.GetHeight() * 0.90), backColor));
            }
            else
            {
                SetSubjBack(MmgHelper.CreateFilledBmp(i * 30, (int)(subj.GetHeight() * 0.90), backColor));
            }
            subjBack.SetPosition(new MmgVector2(subj.GetX() + MmgHelper.ScaleValue(37), subj.GetY() + (int)(subj.GetHeight() * 0.10) / 2));
        }

        /// <summary>
        /// Gets the UI health bar's back color.
        /// </summary>
        /// <returns>The UI health bar's back color. </returns>
        public MmgColor GetBackColor()
        {
            return backColor;
        }

        /// <summary>
        /// Sets the UI health bar's back color.
        /// </summary>
        /// <param name="c">The UI health bar's back color.</param>
        public void SetBackColor(MmgColor c)
        {
            backColor = c;
        }

        /// <summary>
        /// Gets the background subject.
        /// </summary>
        /// <returns>The background subject.</returns>
        public MmgBmp GetSubjBack()
        {
            return subjBack;
        }

        /// <summary>
        /// Sets the background subject.
        /// </summary>
        /// <param name="b">The background subject.</param>
        public void SetSubjBack(MmgBmp b)
        {
            subjBack = b;
        }

        /// <summary>
        /// Gets the game screen this object belongs to.
        /// </summary>
        /// <returns>The game screen this object belongs to.</returns>
        public ScreenGame GetScreen()
        {
            return screen;
        }

        /// <summary>
        /// Sets the game screen this object belongs to.
        /// </summary>
        /// <param name="s">The game screen this object belongs to.</param>
        public void SetScreen(ScreenGame s)
        {
            screen = s;
        }

        /// <summary>
        /// Gets the player type that the UI health bar tracks health for.
        /// </summary>
        /// <returns>The player type that the UI health bar tracks.</returns>
        public MdtPlayerType GetPlayer()
        {
            return player;
        }

        /// <summary>
        /// Sets the player type that the UI health bar tracks health for.
        /// </summary>
        /// <param name="p">The player type that the UI health bar tracks.</param>
        public void SetPlayer(MdtPlayerType p)
        {
            player = p;
        }

        /// <summary>
        /// Gets the subject of the object.
        /// </summary>
        /// <returns>The subject of the object.</returns>
        public MmgBmp GetSubj()
        {
            return subj;
        }

        /// <summary>
        /// Sets the subject of the object.
        /// </summary>
        /// <param name="Subj">The subject of the object.</param>
        public void SetSubj(MmgBmp Subj)
        {
            subj = Subj;
        }

        /// <summary>
        /// Gets a bool flag indicating the associated character is dead.
        /// </summary>
        /// <returns>A bool indicating if the character is dead.</returns>
        public bool GetIsDead()
        {
            return isDead;
        }

        /// <summary>
        /// Sets a bool flag indicating the associated character is dead.
        /// </summary>
        /// <param name="b">A bool indicating if the character is dead.</param>
        public void SetIsDead(bool b)
        {
            isDead = b;
        }

        /// <summary>
        /// Gets the maximum health of the character.
        /// </summary>
        /// <returns>The maximum health of the character.</returns>
        public int GetHealthMax()
        {
            return healthMax;
        }

        /// <summary>
        /// Sets the maximum health of the character.
        /// </summary>
        /// <param name="h">The maximum health of the character.</param>
        public void SetHealthMax(int h)
        {
            healthMax = h;
        }

        /// <summary>
        /// Gets the current health of the character.
        /// </summary>
        /// <returns>The current health of the character.</returns>
        public int GetHealthCurrent()
        {
            return healthCurrent;
        }

        /// <summary>
        /// Sets the current health of the character.
        /// </summary>
        /// <param name="h">The current health of the character.</param>
        public void SetHealthCurrent(int h)
        {
            healthCurrent = h;
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="v">The position of the object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
            subjBack.SetPosition(new MmgVector2(subj.GetX() + MmgHelper.ScaleValue(37), subj.GetY() + (int)(subj.GetHeight() * 0.10) / 2));
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="x">The X coordinate of the object.</param>
        /// <param name="y">The Y coordinate of the object.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            subj.SetPosition(x, y);
            subjBack.SetPosition(new MmgVector2(subj.GetX() + MmgHelper.ScaleValue(37), subj.GetY() + (int)(subj.GetHeight() * 0.10) / 2));
        }

        /// <summary>
        /// Sets the X coordinate of the object.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
            subjBack.SetX(subj.GetX() + MmgHelper.ScaleValue(37));
        }

        /// <summary>
        /// Sets the Y coordinate of the object.
        /// </summary>
        /// <param name="i">The Y coordinate of the object.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
            subjBack.SetY(subj.GetY() + (int)(subj.GetHeight() * 0.10) / 2);
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number. </param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;
            if (isVisible == true)
            {
                subj.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
                lret = true;
            }
            return lret;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                subjBack.MmgDraw(p);
                subj.MmgDraw(p);
            }
        }
    }
}