using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgEventUnitTest_2
    {

        public class EventHandlerParent : MmgEventHandler
        {
            public void MmgHandleEvent(MmgEvent e)
            {

            }
        }

        public class EventHandlerTarget : MmgEventHandler
        {
            public void MmgHandleEvent(MmgEvent e)
            {

            }
        }

        public MmgEventUnitTest_2()
        {
        }

        [TestInitialize]
        public static void setUpClass()
        {
        }

        [TestCleanup]
        public static void tearDownClass()
        {
        }


        public void setUp()
        {
        }


        public void tearDown()
        {
        }

        [TestMethod]
        public void test1()
        {
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

            Assert.AreEqual(e1.GetEventId(), 0);
            Assert.AreEqual(e1.GetEventType(), 1);
            Assert.AreEqual(e1.GetExtra(), payload1);
            Assert.AreEqual(e1.GetMessage(), "Test Message 1");
            Assert.AreEqual(e1.GetParentEventHandler(), ehParent1);
            Assert.AreEqual(e1.GetTargetEventHandler(), ehTarget1);

            e1.SetEventId(2);
            e1.SetEventType(3);
            e1.SetExtra(payload2);
            e1.SetMessage("Test Message 2");
            e1.SetParentEventHandler(ehParent2);
            e1.SetTargetEventHandler(ehTarget2);
            e1.SetPrevEvent(e2);

            Assert.AreEqual(e1.GetEventId(), 2);
            Assert.AreEqual(e1.GetEventType(), 3);
            Assert.AreEqual(e1.GetExtra(), payload2);
            Assert.AreEqual(e1.GetMessage(), "Test Message 2");
            Assert.AreEqual(e1.GetParentEventHandler(), ehParent2);
            Assert.AreEqual(e1.GetTargetEventHandler(), ehTarget2);
            Assert.AreEqual(e1.GetPrevEvent(), e2);

            Assert.AreEqual(MmgEvent.EVENT_ID_UP, 0);
            Assert.AreEqual(MmgEvent.EVENT_ID_DOWN, 1);
            Assert.AreEqual(MmgEvent.EVENT_ID_LEFT, 2);
            Assert.AreEqual(MmgEvent.EVENT_ID_RIGHT, 3);
            Assert.AreEqual(MmgEvent.EVENT_ID_ENTER, 4);
            Assert.AreEqual(MmgEvent.EVENT_ID_SPACE, 5);
            Assert.AreEqual(MmgEvent.EVENT_ID_BACK, 6);
            Assert.AreEqual(MmgEvent.EVENT_ID_ESC, 7);
        }
    }
}