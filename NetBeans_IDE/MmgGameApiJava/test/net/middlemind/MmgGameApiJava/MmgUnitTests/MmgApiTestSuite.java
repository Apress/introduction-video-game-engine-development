package net.middlemind.MmgGameApiJava.MmgUnitTests;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.runner.RunWith;
import org.junit.runners.Suite;

/**
 *
 * @author Victor G. Brusca, Middlemind Games
 */
@RunWith(Suite.class)
@Suite.SuiteClasses(
    {
        Mmg9SliceUnitTest.class
        ,Mmg9SliceUnitTest_2.class
        ,MmgBmpUnitTest.class
        ,MmgBmpUnitTest_2.class            
        ,MmgBmpFontUnitTest_2.class            
        ,MmgCfgFileEntryUnitTest_2.class
        ,MmgColorUnitTest.class
        ,MmgColorUnitTest_2.class
        ,MmgContainerUnitTest.class
        ,MmgContainerUnitTest_2.class
        ,MmgDirUnitTest_2.class
        ,MmgEventUnitTest_2.class
        ,MmgFontUnitTest_2.class
        ,MmgGameScreenUnitTest_2.class
        ,MmgLabelValuePairUnitTest_2.class
        ,MmgLoadingBarUnitTest_2.class
        ,MmgLoadingScreenUnitTest_2.class
        ,MmgMenuContainerUnitTest_2.class
        ,MmgMenuItemUnitTest_2.class
        ,MmgObjUnitTest.class
        ,MmgObjUnitTest_2.class
        ,MmgPenUnitTest_2.class
        ,MmgPositionTweenUnitTest_2.class
        ,MmgPulseUnitTest_2.class
        ,MmgRectUnitTest.class
        ,MmgRectUnitTest_2.class
        ,MmgScrollHorUnitTest_2.class
        ,MmgScrollHorVertUnitTest_2.class            
        ,MmgScrollVertUnitTest_2.class
        ,MmgSizeTweenUnitTest_2.class
        ,MmgSoundUnitTest_2.class
        ,MmgSplashScreenUnitTest_2.class
        ,MmgSpriteSheetUnitTest_2.class
        ,MmgSpriteUnitTest_2.class
        ,MmgTextBlockUnitTest_2.class
        ,MmgTextFieldUnitTest_2.class
        ,MmgVector2UnitTest.class
        ,MmgVector2UnitTest_2.class
        ,MmgVector2IntUnitTest_2.class
    }
)

public class MmgApiTestSuite {

    public static double DELTA_D = 0.00001;
    
    @BeforeClass
    public static void setUpClass() throws Exception {
        
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }

    @Before
    public void setUp() throws Exception {
    }

    @After
    public void tearDown() throws Exception {
    }
}