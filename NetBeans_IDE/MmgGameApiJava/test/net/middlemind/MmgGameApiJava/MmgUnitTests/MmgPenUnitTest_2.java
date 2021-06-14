package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.image.BufferedImage;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import org.junit.Assert;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Victor G. Brusca, Middlemind Games
 */
public class MmgPenUnitTest_2 {
    
    public MmgPenUnitTest_2() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test1() {
        MmgPen p1 = null;
        BufferedImage img = null;
        MmgBmp b1 = null;
        Graphics2D g = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        p1 = new MmgPen();        
        p1.SetCacheOn(true);
        
        Assert.assertEquals(true, p1.GetCacheOn() == true);

        p1.SetCacheOn(false);
        
        Assert.assertEquals(true, p1.GetCacheOn() == false);        
    
        p1.SetColor(Color.RED);
        
        Assert.assertEquals(true, p1.GetColor().equals(Color.RED));        
        Assert.assertEquals(true, p1.GetColor().equals(Color.RED));

        img = new BufferedImage(64, 64, BufferedImage.TYPE_INT_ARGB);
        g = img.createGraphics();
        g.drawImage(b1.GetImage(), 0, 0, null);
        g.dispose();         
        
        p1.SetGraphics(g);
        p1.SetGraphicsColor(Color.BLUE);
        Assert.assertEquals(true, p1.GetGraphics().equals(g));
        Assert.assertEquals(true, p1.GetSpriteBatch().equals(g));
        Assert.assertEquals(true, p1.GetGraphicsColor().equals(Color.BLUE));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgPen p1 = null;
        BufferedImage img = null;
        MmgBmp b1 = null;
        Graphics2D g = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        img = new BufferedImage(64, 64, BufferedImage.TYPE_INT_ARGB);
        g = img.createGraphics();
        g.drawImage(b1.GetImage(), 0, 0, null);
        g.dispose();        
                
        p1 = new MmgPen(g);        
        p1.SetCacheOn(true);
        
        Assert.assertEquals(true, p1.GetCacheOn() == true);

        p1.SetCacheOn(false);
        
        Assert.assertEquals(true, p1.GetCacheOn() == false);        
    
        p1.SetColor(Color.RED);
        
        Assert.assertEquals(true, p1.GetColor().equals(Color.RED));

        img = new BufferedImage(64, 64, BufferedImage.TYPE_INT_ARGB);
        g = img.createGraphics();
        g.drawImage(b1.GetImage(), 0, 0, null);
        g.dispose();         
         
        p1.SetGraphics(g);
        p1.SetGraphicsColor(Color.BLUE);
        Assert.assertEquals(true, p1.GetGraphics().equals(g));
        Assert.assertEquals(true, p1.GetSpriteBatch().equals(g));
        Assert.assertEquals(true, p1.GetGraphicsColor().equals(Color.BLUE));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgPen p1 = null;
        BufferedImage img = null;
        MmgBmp b1 = null;
        Graphics2D g = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");        
        img = new BufferedImage(64, 64, BufferedImage.TYPE_INT_ARGB);
        g = img.createGraphics();
        g.drawImage(b1.GetImage(), 0, 0, null);
        g.dispose();        
                
        p1 = new MmgPen(g, Color.BLACK);        
        p1.SetCacheOn(true);
        
        Assert.assertEquals(true, p1.GetCacheOn() == true);

        p1.SetCacheOn(false);
        
        Assert.assertEquals(true, p1.GetCacheOn() == false);        
    
        p1.SetColor(Color.RED);
        
        Assert.assertEquals(true, p1.GetColor().equals(Color.RED));
        Assert.assertEquals(true, p1.GetColor().equals(Color.RED));

        img = new BufferedImage(64, 64, BufferedImage.TYPE_INT_ARGB);
        g = img.createGraphics();
        g.drawImage(b1.GetImage(), 0, 0, null);
        g.dispose();         
        
        p1.SetGraphics(g);
        p1.SetGraphicsColor(Color.BLUE);
        Assert.assertEquals(true, p1.GetGraphics().equals(g));
        Assert.assertEquals(true, p1.GetSpriteBatch().equals(g));
        Assert.assertEquals(true, p1.GetGraphicsColor().equals(Color.BLUE));
    }    
}