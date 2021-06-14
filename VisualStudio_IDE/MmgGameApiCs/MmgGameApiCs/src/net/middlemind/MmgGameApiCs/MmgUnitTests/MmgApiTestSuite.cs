using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    public class MmgApiTestSuite
    {
        public static double DELTA_D = 0.00001;

        public static void setUpClass()
        {
        }

        public static void tearDownClass()
        {
        }

        public void setUp()
        {
        }

        public void tearDown()
        {
        }

        public void runTestSuite()
        {
            MmgHelper.wr("");
            MmgHelper.wr("");
            int count = 0;
            try
            {
                Mmg9SliceUnitTest t1 = new Mmg9SliceUnitTest();
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                t1.testScaling();
                count++;
                MmgHelper.wr("Mmg9SliceUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("Mmg9SliceUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                Mmg9SliceUnitTest_2 t1 = new Mmg9SliceUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("Mmg9SliceUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("Mmg9SliceUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgBmpFontUnitTest_2 t1 = new MmgBmpFontUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgBmpFontUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgBmpFontUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgBmpUnitTest t1 = new MmgBmpUnitTest();
                t1.testEquals();
                count++;
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                t1.testScaling();
                count++;
                MmgHelper.wr("MmgBmpUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgBmpUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgBmpUnitTest_2 t1 = new MmgBmpUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                t1.test5();
                count++;
                t1.test6();
                count++;
                MmgHelper.wr("MmgBmpUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgBmpUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgCfgFileEntryUnitTest_2 t1 = new MmgCfgFileEntryUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                MmgHelper.wr("MmgCfgFileEntryUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgCfgFileEntryUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgColorUnitTest t1 = new MmgColorUnitTest();
                t1.testStaticMembers();
                count++;
                t1.testEquals();
                count++;
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                MmgHelper.wr("MmgColorUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgColorUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgColorUnitTest_2 t1 = new MmgColorUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgColorUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgColorUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgContainerUnitTest t1 = new MmgContainerUnitTest();
                t1.testConstructors();
                count++;
                MmgHelper.wr("MmgContainerUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgContainerUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgContainerUnitTest_2 t1 = new MmgContainerUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                MmgHelper.wr("MmgContainerUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgContainerUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgDirUnitTest_2 t1 = new MmgDirUnitTest_2();
                t1.test1();
                count++;
                MmgHelper.wr("MmgDirUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgDirUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgEventUnitTest_2 t1 = new MmgEventUnitTest_2();
                t1.test1();
                count++;
                MmgHelper.wr("MmgEventUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgEventUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgFontUnitTest_2 t1 = new MmgFontUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                t1.test5();
                count++;
                t1.test6();
                count++;
                MmgHelper.wr("MmgFontUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgFontUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgGameScreenUnitTest_2 t1 = new MmgGameScreenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgGameScreenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgGameScreenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgLabelValuePairUnitTest_2 t1 = new MmgLabelValuePairUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                MmgHelper.wr("MmgLabelValuePairUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgLabelValuePairUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgLoadingBarUnitTest_2 t1 = new MmgLoadingBarUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgLoadingBarUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgLoadingBarUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgLoadingScreenUnitTest_2 t1 = new MmgLoadingScreenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgLoadingScreenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgLoadingScreenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgMenuContainerUnitTest_2 t1 = new MmgMenuContainerUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                MmgHelper.wr("MmgMenuContainerUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgMenuContainerUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgMenuItemUnitTest_2 t1 = new MmgMenuItemUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgMenuItemUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgMenuItemUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgObjUnitTest t1 = new MmgObjUnitTest();
                t1.testEquals();
                count++;
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                MmgHelper.wr("MmgObjUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgObjUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgObjUnitTest_2 t1 = new MmgObjUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                t1.test5();
                count++;
                t1.test6();
                count++;
                MmgHelper.wr("MmgObjUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgObjUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgPenUnitTest_2 t1 = new MmgPenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgPenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgPenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgPositionTweenUnitTest_2 t1 = new MmgPositionTweenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgPositionTweenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgPositionTweenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgPulseUnitTest_2 t1 = new MmgPulseUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgPulseUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgPulseUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgRectUnitTest t1 = new MmgRectUnitTest();
                t1.testStaticMembers();
                count++;
                t1.testEquals();
                count++;
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                MmgHelper.wr("MmgRectUnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgRectUnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgRectUnitTest_2 t1 = new MmgRectUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                MmgHelper.wr("MmgRectUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgRectUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgScrollHorUnitTest_2 t1 = new MmgScrollHorUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgScrollHorUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgScrollHorUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgScrollHorVertUnitTest_2 t1 = new MmgScrollHorVertUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgScrollHorVertUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgScrollHorVertUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgScrollVertUnitTest_2 t1 = new MmgScrollVertUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgScrollVertUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgScrollVertUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgSizeTweenUnitTest_2 t1 = new MmgSizeTweenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgSizeTweenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgSizeTweenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgSoundUnitTest_2 t1 = new MmgSoundUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgSoundUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgSoundUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgSplashScreenUnitTest_2 t1 = new MmgSplashScreenUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgSplashScreenUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgSplashScreenUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgSpriteSheetUnitTest_2 t1 = new MmgSpriteSheetUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgSpriteSheetUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgSpriteSheetUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgSpriteUnitTest_2 t1 = new MmgSpriteUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                MmgHelper.wr("MmgSpriteUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgSpriteUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgTextBlockUnitTest_2 t1 = new MmgTextBlockUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgTextBlockUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgTextBlockUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgTextFieldUnitTest_2 t1 = new MmgTextFieldUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                MmgHelper.wr("MmgTextFieldUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgTextFieldUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgVector2IntUnitTest_2 t1 = new MmgVector2IntUnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                t1.test5();
                count++;
                t1.test6();
                count++;
                t1.test7();
                count++;
                t1.test8();
                count++;
                MmgHelper.wr("MmgVector2IntUnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgVector2IntUnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgVector2UnitTest t1 = new MmgVector2UnitTest();
                t1.testStaticMembers();
                count++;
                t1.testEquals();
                count++;
                t1.testGettersSetters();
                count++;
                t1.testCloning();
                count++;
                t1.testConstructors();
                count++;
                MmgHelper.wr("MmgVector2UnitTest: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgVector2UnitTest: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("");
            MmgHelper.wr("");
            try
            {
                MmgVector2UnitTest_2 t1 = new MmgVector2UnitTest_2();
                t1.test1();
                count++;
                t1.test2();
                count++;
                t1.test3();
                count++;
                t1.test4();
                count++;
                t1.test5();
                count++;
                t1.test6();
                count++;
                t1.test7();
                count++;
                t1.test8();
                count++;
                MmgHelper.wr("MmgVector2UnitTest_2: Passed!");
            }
            catch (Exception e)
            {
                MmgHelper.wr("MmgVector2UnitTest_2: Failed:");
                MmgHelper.wrErr(e);
            }

            MmgHelper.wr("Ran " + count + " tests!!");
        }
    }
}