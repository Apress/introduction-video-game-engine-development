package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
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
public class MmgEventUnitTest_2 {
    
    public class EventHandlerParent implements MmgEventHandler {
        @Override
        public void MmgHandleEvent(MmgEvent e) {

        }        
    }
    
    public class EventHandlerTarget implements MmgEventHandler {
        @Override
        public void MmgHandleEvent(MmgEvent e) {

        }        
    }    
    
    public MmgEventUnitTest_2() {
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
        EventHandlerParent ehParent1 = new EventHandlerParent();
        EventHandlerTarget ehTarget1 = new EventHandlerTarget();
        EventHandlerParent ehParent2 = new EventHandlerParent();
        EventHandlerTarget ehTarget2 = new EventHandlerTarget();
        
        MmgEvent e1;
        MmgEvent e2;        
        Object payload1 = new Object();
        Object payload2 = new Object();        
                
        e1 = new MmgEvent(ehParent1, "Test Message 1", 0, 1, ehTarget1, payload1);
        e2 = new MmgEvent(ehParent2, "Test Message 2", 8, 9, ehTarget2, payload2);        
    
        Assert.assertEquals(e1.GetEventId(), 0);
        Assert.assertEquals(e1.GetEventType(), 1);
        Assert.assertEquals(e1.GetExtra(), payload1);
        Assert.assertEquals(e1.GetMessage(), "Test Message 1");
        Assert.assertEquals(e1.GetParentEventHandler(), ehParent1);
        Assert.assertEquals(e1.GetTargetEventHandler(), ehTarget1);

        e1.SetEventId(2);
        e1.SetEventType(3);
        e1.SetExtra(payload2);
        e1.SetMessage("Test Message 2");
        e1.SetParentEventHandler(ehParent2);
        e1.SetTargetEventHandler(ehTarget2);        
        e1.SetPrevEvent(e2);
        
        Assert.assertEquals(e1.GetEventId(), 2);
        Assert.assertEquals(e1.GetEventType(), 3);
        Assert.assertEquals(e1.GetExtra(), payload2);
        Assert.assertEquals(e1.GetMessage(), "Test Message 2");
        Assert.assertEquals(e1.GetParentEventHandler(), ehParent2);
        Assert.assertEquals(e1.GetTargetEventHandler(), ehTarget2);        
        Assert.assertEquals(e1.GetPrevEvent(), e2);
        
        Assert.assertEquals(MmgEvent.EVENT_ID_UP, 0);
        Assert.assertEquals(MmgEvent.EVENT_ID_DOWN, 1);
        Assert.assertEquals(MmgEvent.EVENT_ID_LEFT, 2);
        Assert.assertEquals(MmgEvent.EVENT_ID_RIGHT, 3);
        Assert.assertEquals(MmgEvent.EVENT_ID_ENTER, 4);
        Assert.assertEquals(MmgEvent.EVENT_ID_SPACE, 5);
        Assert.assertEquals(MmgEvent.EVENT_ID_BACK, 6);
        Assert.assertEquals(MmgEvent.EVENT_ID_ESC, 7);        
    }
}