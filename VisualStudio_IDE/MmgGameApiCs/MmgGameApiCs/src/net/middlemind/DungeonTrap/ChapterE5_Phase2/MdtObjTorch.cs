using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// A class that represents a game torch.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtObjTorch : MdtObj
    {
        /// <summary>
        /// An MmgBmp object to display when the torch is off.
        /// </summary>
        public MmgBmp subjOff = null;

        /// <summary>
        /// A bool flag indicating if the torch is burning (on) or not (off).
        /// </summary>
        public bool isBurning = false;

        /// <summary>
        /// A private variable used in internal methods.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// A basic constructor for the large table class.
        /// </summary>
        public MdtObjTorch()
        {
            MmgBmp src = MmgHelper.GetBasicCachedBmp("torch_spritesheet_lg.png");
            MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
            MmgSprite subj = new MmgSprite(ssSrc.GetFrames());
            subj.SetMsPerFrame(280);
            SetSubj(subj);
            SetSubjOff(MmgHelper.GetBasicCachedBmp("torch_off.png"));
            SetMdtType(MdtObjType.OBJECT);
            SetMdtSubType(MdtObjSubType.OBJECT_TORCH);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
        }

        /// <summary>
        /// A constructor for the torch class that let's you specify the subject and the torch off image.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        /// <param name="SubjOff">The torch off image.</param>
        public MdtObjTorch(MmgSprite Subj, MmgBmp SubjOff)
            : base(Subj, MdtObjType.OBJECT, MdtObjSubType.OBJECT_TORCH)
        {
            GetSubj().SetMsPerFrame(280);
            SetSubjOff(SubjOff);
        }

        /// <summary>
        /// Gets the subject of the class.
        /// </summary>
        /// <returns>The subject of the class.</returns>
        public new MmgSprite GetSubj()
        {
            return (MmgSprite)subj;
        }

        /// <summary>
        /// Gets the torch off subject of the class.
        /// </summary>
        /// <returns>The torch off subject.</returns>
        public virtual MmgBmp GetSubjOff()
        {
            return subjOff;
        }

        /// <summary>
        /// Sets the torch off subject of the class.
        /// </summary>
        /// <param name="SubjOff">The torch off subject.</param>
        public virtual void SetSubjOff(MmgBmp SubjOff)
        {
            subjOff = SubjOff;
        }

        /// <summary>
        /// Gets a bool flag indicating if the torch is burning (on) or not (off).
        /// </summary>
        /// <returns>A bool flag indicating if the torch is on.</returns>
        public virtual bool GetIsBurning()
        {
            return isBurning;
        }

        /// <summary>
        /// Sets a bool flag indicating if the torch is burning (on) or not (off).
        /// </summary>
        /// <param name="b">A bool flag indicating if the torch is on.</param>
        public virtual void SetIsBurning(bool b)
        {
            isBurning = b;
        }

        /// <summary>
        /// Sets the position of the object.
        /// </summary>
        /// <param name="v">The position of the object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            subj.SetPosition(v);
            subjOff.SetPosition(v);
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
            subjOff.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the X coordinate of the object's position.
        /// </summary>
        /// <param name="i">The X coordinate of the object.</param>
        public override void SetX(int i)
        {
            base.SetX(i);
            subj.SetX(i);
            subjOff.SetX(i);
        }

        /// <summary>
        /// Sets the Y coordinate of the object's position.
        /// </summary>
        /// <param name="i">The Y coordinate of the object.</param>
        public override void SetY(int i)
        {
            base.SetY(i);
            subj.SetY(i);
            subjOff.SetY(i);
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
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
                if (isBurning)
                {
                    subj.MmgDraw(p);
                }
                else
                {
                    subjOff.MmgDraw(p);
                }
            }
        }
    }
}