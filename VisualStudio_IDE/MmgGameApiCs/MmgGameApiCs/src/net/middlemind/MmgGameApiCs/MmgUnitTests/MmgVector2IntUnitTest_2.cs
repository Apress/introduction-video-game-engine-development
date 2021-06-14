using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgVector2IntUnitTest_2
    {
        public MmgVector2IntUnitTest_2()
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
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int();
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test2()
        {
            MmgVector2Int v0 = MmgVector2Int.GetOriginVec();
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(v0);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test3()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0.0d, 0.0d);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test4()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0.0d);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test5()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0.0f, 0.0f);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test6()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0.0f);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test7()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0, 0);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }

        [TestMethod]
        public void test8()
        {
            MmgVector2Int v1;
            MmgVector2Int v2;
            double[] v3;
            double[] v4 = new double[] { 1.1, 1.2 };
            double d1 = 2.1d;
            float f1 = 3.24f;
            int i1 = 10;

            v1 = new MmgVector2Int(0);
            Assert.AreEqual(v1.GetX(), 0);
            Assert.AreEqual(v1.GetY(), 0);

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v3 = v1.GetVector();
            Assert.AreEqual(0, (int)v3[0]);
            Assert.AreEqual(0, (int)v3[1]);

            Assert.AreEqual(0, v1.GetX());
            Assert.AreEqual(0, (int)v1.GetXDouble());
            Assert.AreEqual(0, (int)v1.GetXFloat());

            Assert.AreEqual(0, (int)v1.GetY());
            Assert.AreEqual(0, (int)v1.GetYDouble());
            Assert.AreEqual(0, (int)v1.GetYFloat());

            v1.SetVector(v4);
            Assert.AreEqual(1, v1.GetX());
            Assert.AreEqual(1, (int)v1.GetXDouble());
            Assert.AreEqual(1, (int)v1.GetXFloat());

            Assert.AreEqual(1, (int)v1.GetY());
            Assert.AreEqual(1, (int)v1.GetYDouble());
            Assert.AreEqual(1, (int)v1.GetYFloat());

            v1.SetX(i1);
            Assert.AreEqual(10, (int)v1.GetX());

            v1.SetX(d1);
            Assert.AreEqual(2, (int)v1.GetXDouble());

            v1.SetX(f1);
            Assert.AreEqual(3, (int)v1.GetXFloat());

            v1.SetY(i1);
            Assert.AreEqual(10, (int)v1.GetY());

            v1.SetY(d1);
            Assert.AreEqual(2, (int)v1.GetYDouble());

            v1.SetY(f1);
            Assert.AreEqual(3, (int)v1.GetYFloat());

            v2 = v1.Clone();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneDouble();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneFloat();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            v2 = v1.CloneInt();
            Assert.AreEqual(true, v2.ApiEquals(v1));
            Assert.AreEqual(true, v1.ApiEquals(v2));
            Assert.AreEqual(true, v1.ApiEquals(v1));

            Assert.AreEqual("MmgVector2Int: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
        }
    }
}