using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;

//Converted equals and Equals
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgContainerUnitTest_2
    {
        public MmgContainerUnitTest_2()
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
            MmgContainer c1, c2, c3;
            MmgObj o1, o2, o3;
            Object[] a1;

            o1 = new MmgObj();
            o2 = new MmgObj();
            c1 = new MmgContainer();
            c2 = new MmgContainer();

            Assert.AreEqual(MmgContainer.INITIAL_SIZE, 10);
            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetIsDirty());

            c1.SetPosition(MmgVector2Int.GetUnitVec());

            Assert.AreEqual(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));

            c1.Add(o1);
            c1.Add(o1);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.AddAt(2, o2);

            Assert.AreEqual(c1.GetCount(), 3);

            o3 = c1.GetAt(2);

            Assert.AreEqual(o3, o2);

            o3 = c1.RemoveAt(2);

            Assert.AreEqual(o3, o2);
            Assert.AreEqual(c1.GetCount(), 2);

            c1.Remove(o1);

            Assert.AreEqual(c1.GetCount(), 1);

            a1 = c1.GetArray();

            Assert.AreEqual(a1.Length, c1.GetCount());
            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
            }

            //Restore has parent value after shared reference set it to false
            c1.GetAt(0).SetHasParent(true);
            c1.GetAt(0).SetParent(c1);

            c3 = c1.CloneTyped();

            Assert.AreEqual(true, c1.ApiEquals(c3));
            Assert.AreEqual(false, c1.ApiEquals(c2));

            c1.SetIsDirty(true);

            Assert.AreEqual(c1.GetIsDirty(), true);

            MmgObj obj1 = (MmgObj)c1;
            Assert.AreEqual(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
            Assert.AreEqual(true, obj1.ApiEquals(c1));

            List<MmgObj> container = c1.GetContainer();
            c1.Clear();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetContainer().Equals(container));

            MmgObj m1 = c1.Clone();
            MmgObj m2 = new MmgObj();
            Assert.AreEqual(true, ((MmgObj)c1).ApiEquals(m1));
            Assert.AreEqual(false, ((MmgObj)c1).ApiEquals(m2));

            c1.Add(o1);
            c1.Add(o2);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.Reset();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(false, c1.GetContainer().Equals(container));

            c1.Add(o1);
            c1.Add(o2);
            o3 = c1.GetChildAt(0);

            Assert.AreEqual(true, o3.ApiEquals(o1));
            Assert.AreEqual(true, o3.Equals(o1));

            c1.SetPosition(10, 10);
            o3.SetPosition(10, 10);

            Assert.AreEqual(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
            Assert.AreEqual(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
        }

        [TestMethod]
        public void test2()
        {
            MmgContainer c1, c2, c3;
            MmgObj o1, o2, o3;
            Object[] a1;

            o1 = new MmgObj();
            o2 = new MmgObj();
            c1 = new MmgContainer(new MmgObj());
            c2 = new MmgContainer();

            Assert.AreEqual(MmgContainer.INITIAL_SIZE, 10);
            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetIsDirty());

            c1.SetPosition(MmgVector2Int.GetUnitVec());

            Assert.AreEqual(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));

            c1.Add(o1);
            c1.Add(o1);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.AddAt(2, o2);

            Assert.AreEqual(c1.GetCount(), 3);

            o3 = c1.GetAt(2);

            Assert.AreEqual(o3, o2);

            o3 = c1.RemoveAt(2);

            Assert.AreEqual(o3, o2);
            Assert.AreEqual(c1.GetCount(), 2);

            c1.Remove(o1);

            Assert.AreEqual(c1.GetCount(), 1);

            a1 = c1.GetArray();

            Assert.AreEqual(a1.Length, c1.GetCount());
            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
            }

            //Restore has parent value after shared reference set it to false
            c1.GetAt(0).SetHasParent(true);
            c1.GetAt(0).SetParent(c1);

            c3 = c1.CloneTyped();

            Assert.AreEqual(true, c1.ApiEquals(c3));
            Assert.AreEqual(false, c1.ApiEquals(c2));

            c1.SetIsDirty(true);

            Assert.AreEqual(c1.GetIsDirty(), true);

            MmgObj obj1 = (MmgObj)c1;
            Assert.AreEqual(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
            Assert.AreEqual(true, obj1.ApiEquals(c1));

            List<MmgObj> container = c1.GetContainer();
            c1.Clear();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetContainer().Equals(container));

            MmgObj m1 = c1.Clone();
            MmgObj m2 = new MmgObj();
            Assert.AreEqual(true, ((MmgObj)c1).ApiEquals(m1));
            Assert.AreEqual(false, ((MmgObj)c1).ApiEquals(m2));

            c1.Add(o1);
            c1.Add(o2);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.Reset();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(false, c1.GetContainer().Equals(container));

            c1.Add(o1);
            c1.Add(o2);
            o3 = c1.GetChildAt(0);

            Assert.AreEqual(true, o3.ApiEquals(o1));
            Assert.AreEqual(true, o3.Equals(o1));

            c1.SetPosition(10, 10);
            o3.SetPosition(10, 10);

            Assert.AreEqual(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
            Assert.AreEqual(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
        }

        [TestMethod]
        public void test3()
        {
            MmgContainer c1, c2, c3;
            MmgObj o1, o2, o3;
            Object[] a1;

            List<MmgObj> objects = new List<MmgObj>();

            o1 = new MmgObj();
            o2 = new MmgObj();
            c1 = new MmgContainer(objects);
            c2 = new MmgContainer();

            Assert.AreEqual(MmgContainer.INITIAL_SIZE, 10);
            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetIsDirty());

            c1.SetPosition(MmgVector2Int.GetUnitVec());

            Assert.AreEqual(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));

            c1.Add(o1);
            c1.Add(o1);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.AddAt(2, o2);

            Assert.AreEqual(c1.GetCount(), 3);

            o3 = c1.GetAt(2);

            Assert.AreEqual(o3, o2);

            o3 = c1.RemoveAt(2);

            Assert.AreEqual(o3, o2);
            Assert.AreEqual(c1.GetCount(), 2);

            c1.Remove(o1);

            Assert.AreEqual(c1.GetCount(), 1);

            a1 = c1.GetArray();

            Assert.AreEqual(a1.Length, c1.GetCount());
            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
            }

            //Restore has parent value after shared reference set it to false
            c1.GetAt(0).SetHasParent(true);
            c1.GetAt(0).SetParent(c1);

            c3 = c1.CloneTyped();

            Assert.AreEqual(true, c1.ApiEquals(c3));
            Assert.AreEqual(false, c1.ApiEquals(c2));

            c1.SetIsDirty(true);

            Assert.AreEqual(c1.GetIsDirty(), true);

            MmgObj obj1 = (MmgObj)c1;
            Assert.AreEqual(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
            Assert.AreEqual(true, obj1.Equals(c1));

            List<MmgObj> container = c1.GetContainer();
            c1.Clear();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetContainer().Equals(container));

            MmgObj m1 = c1.Clone();
            MmgObj m2 = new MmgObj();
            Assert.AreEqual(true, ((MmgObj)c1).ApiEquals(m1));
            Assert.AreEqual(false, ((MmgObj)c1).ApiEquals(m2));

            c1.Add(o1);
            c1.Add(o2);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.Reset();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(false, c1.GetContainer().Equals(container));

            c1.Add(o1);
            c1.Add(o2);
            o3 = c1.GetChildAt(0);

            Assert.AreEqual(true, o3.ApiEquals(o1));
            Assert.AreEqual(true, o3.Equals(o1));

            c1.SetPosition(10, 10);
            o3.SetPosition(10, 10);

            Assert.AreEqual(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
            Assert.AreEqual(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
        }

        [TestMethod]
        public void test4()
        {
            MmgContainer c1, c2, c3;
            MmgObj o1, o2, o3;
            Object[] a1;

            List<MmgObj> objects = new List<MmgObj>();

            o1 = new MmgObj();
            o2 = new MmgObj();
            c1 = new MmgContainer(new MmgContainer());
            c2 = new MmgContainer();

            Assert.AreEqual(MmgContainer.INITIAL_SIZE, 10);
            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetIsDirty());

            c1.SetPosition(MmgVector2Int.GetUnitVec());

            Assert.AreEqual(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));

            c1.Add(o1);
            c1.Add(o1);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.AddAt(2, o2);

            Assert.AreEqual(c1.GetCount(), 3);

            o3 = c1.GetAt(2);

            Assert.AreEqual(o3, o2);

            o3 = c1.RemoveAt(2);

            Assert.AreEqual(o3, o2);
            Assert.AreEqual(c1.GetCount(), 2);

            c1.Remove(o1);

            Assert.AreEqual(c1.GetCount(), 1);

            a1 = c1.GetArray();

            Assert.AreEqual(a1.Length, c1.GetCount());
            for (int i = 0; i < a1.Length; i++)
            {
                Assert.AreEqual(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
            }

            //Restore has parent value after shared reference set it to false
            c1.GetAt(0).SetHasParent(true);
            c1.GetAt(0).SetParent(c1);

            c3 = c1.CloneTyped();

            Assert.AreEqual(true, c1.ApiEquals(c3));
            Assert.AreEqual(false, c1.ApiEquals(c2));

            c1.SetIsDirty(true);

            Assert.AreEqual(c1.GetIsDirty(), true);

            MmgObj obj1 = (MmgObj)c1;
            Assert.AreEqual(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
            Assert.AreEqual(true, obj1.ApiEquals(c1));

            List<MmgObj> container = c1.GetContainer();
            c1.Clear();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(true, c1.GetContainer().Equals(container));

            MmgObj m1 = c1.Clone();
            MmgObj m2 = new MmgObj();
            Assert.AreEqual(true, ((MmgObj)c1).ApiEquals(m1));
            Assert.AreEqual(false, ((MmgObj)c1).ApiEquals(m2));

            c1.Add(o1);
            c1.Add(o2);

            Assert.AreEqual(c1.GetCount(), 2);

            c1.Reset();

            Assert.AreEqual(c1.GetCount(), 0);
            Assert.AreEqual(false, c1.GetContainer().Equals(container));

            c1.Add(o1);
            c1.Add(o2);
            o3 = c1.GetChildAt(0);

            Assert.AreEqual(true, o3.ApiEquals(o1));
            Assert.AreEqual(true, o3.Equals(o1));

            c1.SetPosition(10, 10);
            o3.SetPosition(10, 10);

            Assert.AreEqual(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
            Assert.AreEqual(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
        }
    }
}