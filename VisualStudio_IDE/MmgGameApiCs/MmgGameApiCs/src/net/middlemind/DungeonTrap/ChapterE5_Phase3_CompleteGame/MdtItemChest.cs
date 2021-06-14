using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame
{
    /// <summary>
    /// A class that represents a treasure chest.
    ///
    /// @author Victor G. Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtItemChest : MdtItem
    {
        /// <summary>
        /// The image used to show that the treasure chest is open.
        /// </summary>
        public MmgBmp subjOpen = null;

        /// <summary>
        /// A bool flag indicating that the treasure chest is still closed.
        /// </summary>
        public bool isClosed = true;

        /// <summary>
        /// A private variable used in internal methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// The object that is contained inside the chest.
        /// </summary>
        public MdtBase treasureInside = null;

        /// <summary>
        /// A basic constructor for the treasure chest class.
        /// </summary>
        public MdtItemChest()
        {
            MmgBmp src = MmgHelper.GetBasicCachedBmp("chest_spritesheet_lg.png");
            MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
            MmgSprite subj = new MmgSprite(ssSrc.GetFrames());
            subj.SetMsPerFrame(280);
            SetSubj(subj);
            SetMdtType(MdtObjType.ITEM);
            SetMdtSubType(MdtObjSubType.ITEM_CHEST);
            SetSubjOpen(MmgHelper.GetBasicCachedBmp("chest_open_lg.png"));
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
        }

        /// <summary>
        /// A constructor for the treasure chest class that takes a subject and an open chest image as arguments.
        /// </summary>
        /// <param name="Subj">The subject of this treasure chest class.</param>
        /// <param name="Open">The open image of this treasure chest class.</param>
        public MdtItemChest(MmgSprite Subj, MmgBmp Open)
            : base(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_CHEST, MdtPointsType.PTS_100)
        {
            GetSubj().SetMsPerFrame(280);
            SetSubjOpen(Open);
        }

        /// <summary>
        /// Gets the object that is inside the treasure chest.
        /// </summary>
        /// <returns>The object that is inside the treasure chest.</returns>
        public virtual MdtBase GetTreasureInside()
        {
            return treasureInside;
        }

        /// <summary>
        /// Sets the object that is inside the treasure chest.
        /// </summary>
        /// <param name="obj">The object that is inside the treasure chest.</param>
        public void SetTreasureInside(MdtBase obj)
        {
            treasureInside = obj;
        }

        /// <summary>
        /// Gets the subject of this treasure chest class.
        /// </summary>
        /// <returns>The subject of this treasure chest class.</returns>
        public new MmgSprite GetSubj()
        {
            return (MmgSprite)subj;
        }

        /// <summary>
        /// Gets the image used to display an open treasure chest.
        /// </summary>
        /// <returns>The image used to display an open treasure chest.</returns>
        public virtual MmgBmp GetSubjOpen()
        {
            return subjOpen;
        }

        /// <summary>
        /// Sets the image used to display an open treasure chest.
        /// </summary>
        /// <param name="Open">The image used to display an open treasure chest.</param>
        public virtual void SetSubjOpen(MmgBmp Open)
        {
            subjOpen = Open;
        }

        /// <summary>
        /// Gets a bool flag indicating that the treasure chest is closed.
        /// </summary>
        /// <returns>A bool flag indicating if the treasure chest is open or closed.</returns>
        public virtual bool GetIsClosed()
        {
            return isClosed;
        }

        /// <summary>
        /// Sets a bool flag indicating that the treasure chest is closed.
        /// </summary>
        /// <param name="b">A bool flag indicating if the treasure chest is open or closed.</param>
        public virtual void SetIsClosed(bool b)
        {
            isClosed = b;
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="v">The position of the object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
            subjOpen.SetPosition(v);
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
            subjOpen.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the X coordinate of the object's position.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
            subjOpen.SetX(i);
        }

        /// <summary>
        /// Sets the Y coordinate of the object's position.
        /// </summary>
        /// <param name="i">The Y coordinate of the object.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
            subjOpen.SetY(i);
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
                if (isClosed)
                {
                    subj.MmgDraw(p);
                }
                else
                {
                    subjOpen.MmgDraw(p);
                }
            }
        }
    }
}