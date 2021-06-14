using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a game loading screen.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgLoadingScreen : MmgGameScreen
    {
        /// <summary>
        /// A loading bar to use with this loading screen.
        /// </summary>
        private MmgLoadingBar loadingBar;

        /// <summary>
        /// A loading bar vertical offset value.
        /// </summary>
        private float loadingBarOffsetBottom = 0.10f;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgLoadingScreen() : base()
        {
        }

        /// <summary>
        /// Constructor for this class that sets the loading bar and the loading bar's vertical offset.
        /// </summary>
        /// <param name="LoadingBar">The loading bar to use.</param>
        /// <param name="lBarOff">The loading bar vertical offset.</param>
        public MmgLoadingScreen(MmgLoadingBar LoadingBar, float lBarOff) : base()
        {
            SetLoadingBar(LoadingBar, lBarOff);
        }

        /// <summary>
        /// Constructor for this class that sets the value of local attributes based on the attributes
        /// of the given argument.
        /// </summary>
        /// <param name="obj">The MmgLoadingScreen to use to set local attributes.</param>
        public MmgLoadingScreen(MmgLoadingScreen obj) : base()
        {
            if (obj.GetLoadingBar() == null)
            {
                SetLoadingBar(obj.GetLoadingBar(), obj.GetLoadingBarOffsetBottom());
            }
            else
            {
                SetLoadingBar(obj.GetLoadingBar().CloneTyped(), obj.GetLoadingBarOffsetBottom());
            }

            if (obj.GetBackground() == null)
            {
                SetBackground(obj.GetBackground());
            }
            else
            {
                SetBackground(obj.GetBackground().Clone());
            }

            if (obj.GetFooter() == null)
            {
                SetFooter(obj.GetFooter());
            }
            else
            {
                SetFooter(obj.GetFooter().Clone());
            }

            SetHasParent(obj.GetHasParent());

            if (obj.GetHeader() == null)
            {
                SetHeader(obj.GetHeader());
            }
            else
            {
                SetHeader(obj.GetHeader().Clone());
            }

            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetLeftCursor() == null)
            {
                SetLeftCursor(obj.GetLeftCursor());
            }
            else
            {
                SetLeftCursor(obj.GetLeftCursor().Clone());
            }

            if (obj.GetMenu() == null)
            {
                SetMenu(obj.GetMenu());
            }
            else
            {
                SetMenu(obj.GetMenu().CloneTyped());
            }

            SetMenuCursorLeftOffsetX(obj.GetMenuCursorLeftOffsetX());
            SetMenuCursorLeftOffsetY(obj.GetMenuCursorLeftOffsetY());
            SetMenuCursorRightOffsetX(obj.GetMenuCursorRightOffsetX());
            SetMenuCursorRightOffsetY(obj.GetMenuCursorRightOffsetY());
            SetMenuIdx(obj.GetMenuIdx());
            SetMenuOn(obj.GetMenuOn());
            SetMenuStart(obj.GetMenuStart());
            SetMenuStop(obj.GetMenuStop());

            if (obj.GetMessage() == null)
            {
                SetMessage(obj.GetMessage());
            }
            else
            {
                SetMessage(obj.GetMessage().Clone());
            }

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            SetName(obj.GetName());

            if (obj.GetObjects() == null)
            {
                SetObjects(obj.GetObjects());
            }
            else
            {
                SetObjects(obj.GetObjects().CloneTyped());
            }

            SetParent(obj.GetParent());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            if (obj.GetRightCursor() == null)
            {
                SetRightCursor(obj.GetRightCursor());
            }
            else
            {
                SetRightCursor(obj.GetRightCursor().Clone());
            }

            if (obj.GetLoadingBar() != null && obj.GetLoadingBar().GetLoadingBarBack() != null)
            {
                if (GetLoadingBar() != null && GetLoadingBar().GetLoadingBarBack() != null)
                {
                    if (obj.GetLoadingBar().GetLoadingBarBack().GetPosition() != null)
                    {
                        GetLoadingBar().GetLoadingBarBack().SetPosition(obj.GetLoadingBar().GetLoadingBarBack().GetPosition().Clone());
                    }
                }
            }

            if (obj.GetLoadingBar() != null && obj.GetLoadingBar().GetLoadingBarFront() != null)
            {
                if (GetLoadingBar() != null && GetLoadingBar().GetLoadingBarFront() != null)
                {
                    if (obj.GetLoadingBar().GetLoadingBarFront().GetPosition() != null)
                    {
                        GetLoadingBar().GetLoadingBarFront().SetPosition(obj.GetLoadingBar().GetLoadingBarFront().GetPosition().Clone());
                    }
                }
            }

            SetWidth(obj.GetWidth());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgLoadingScreen(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgLoadingScreen CloneTyped()
        {
            return new MmgLoadingScreen(this);
        }

        /// <summary>
        /// Gets the loading bar object of this class.
        /// </summary>
        /// <returns>A loading bar.</returns>
        public virtual MmgLoadingBar GetLoadingBar()
        {
            return loadingBar;
        }

        /// <summary>
        /// Get the loading bar's bottom offset.
        /// </summary>
        /// <returns>The loading bar's bottom offset.</returns>
        public virtual float GetLoadingBarOffsetBottom()
        {
            return loadingBarOffsetBottom;
        }

        /// <summary>
        /// Sets the loading bar and loading bar's bottom offset.
        /// </summary>
        /// <param name="lb">The loading bar to use for this game screen.</param>
        /// <param name="lBarOff">The bottom offset to use for the loading bar.</param>
        public virtual void SetLoadingBar(MmgLoadingBar lb, float lBarOff)
        {
            loadingBar = lb;
            loadingBarOffsetBottom = lBarOff;
            if (loadingBar != null)
            {
                MmgHelper.CenterHorAndBot(loadingBar);
                loadingBar.GetPosition().SetY(GetPosition().GetY() + GetHeight() - loadingBar.GetHeight() - ((float)GetHeight() * (float)loadingBarOffsetBottom));
                loadingBar.GetLoadingBarBack().SetPosition(loadingBar.GetPosition());
                loadingBar.GetLoadingBarFront().SetPosition(loadingBar.GetPosition());
            }
        }

        /// <summary>
        /// The base drawing class for this game screen.
        /// </summary>
        /// <param name="p">The MmgPen object that is used to draw this screen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true && pause == false)
            {
                base.MmgDraw(p);

                if (loadingBar != null)
                {
                    loadingBar.MmgDraw(p);
                }
            }
        }

        /// <summary>
        /// Tests if this object is equal to another MmgLoadingScreen object.
        /// </summary>
        /// <param name="obj">An MmgLoadingScreen object instance to compare to.</param>
        /// <returns>Returns true if the objects are considered equal and false otherwise.</returns>
        public virtual bool ApiEquals(MmgLoadingScreen obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(base.equals((MmgGameScreen)obj))) {
                MmgHelper.wr("MmgGameScreen is not equal!");
            }

            if(!(obj.GetLoadingBarOffsetBottom() == GetLoadingBarOffsetBottom())) {
                MmgHelper.wr("Offset Botton is not equal!");
            }

            if(!(((obj.GetLoadingBar() == null && GetLoadingBar() == null) || (obj.GetLoadingBar() != null && GetLoadingBar() != null && obj.GetLoadingBar().equals(GetLoadingBar()))))) {
                MmgHelper.wr("loading bar is not equal!");
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgGameScreen)obj)
                && obj.GetLoadingBarOffsetBottom() == GetLoadingBarOffsetBottom()
                && ((obj.GetLoadingBar() == null && GetLoadingBar() == null) || (obj.GetLoadingBar() != null && GetLoadingBar() != null && obj.GetLoadingBar().ApiEquals(GetLoadingBar())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}