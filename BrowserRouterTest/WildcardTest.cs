using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

using SteelUnderpants.BrowserRouter.Core;

namespace SteelUnderpants.BrowserRouter.Test
{
    [TestClass]
    public class WildcardTest
    {
        [TestMethod]
        public void TestNoWildcard()
        {
            Wildcard wc = new Wildcard("this does not have wildcards");
            Assert.IsTrue(wc.IsMatch("this does not have wildcards"));
        }

        [TestMethod]
        public void TestRegexEscapted()
        {
            Wildcard wc = new Wildcard(".");
            Assert.IsFalse(wc.IsMatch("X"));
            Assert.IsTrue(wc.IsMatch("."));

            wc = new Wildcard("[a-z]");
            Assert.IsFalse(wc.IsMatch("b"));
            Assert.IsTrue(wc.IsMatch("[a-z]"));

            wc = new Wildcard("a+");
            Assert.IsFalse(wc.IsMatch("aa"));
            Assert.IsTrue(wc.IsMatch("a+"));

            wc = new Wildcard("^$");
            Assert.IsFalse(wc.IsMatch(""));
            Assert.IsTrue(wc.IsMatch("^$"));

            wc = new Wildcard("(abc){1,2}");
            Assert.IsFalse(wc.IsMatch("abcabc"));
            Assert.IsTrue(wc.IsMatch("(abc){1,2}"));
        }

        [TestMethod]
        public void TestWildcard()
        {
            Wildcard wc = new Wildcard("*");
            Assert.IsTrue(wc.IsMatch("asdf"));
            Assert.IsTrue(wc.IsMatch("foobar"));
            Assert.IsTrue(wc.IsMatch(""));

            wc = new Wildcard("dog*");
            Assert.IsTrue(wc.IsMatch("dog"));
            Assert.IsTrue(wc.IsMatch("doggy"));
            Assert.IsTrue(wc.IsMatch("doggies"));
            Assert.IsFalse(wc.IsMatch("cat"));

            wc = new Wildcard("d*g");
            Assert.IsTrue(wc.IsMatch("dog"));
            Assert.IsTrue(wc.IsMatch("doug"));
            Assert.IsFalse(wc.IsMatch("cat"));
            Assert.IsFalse(wc.IsMatch("doggy"));

            wc = new Wildcard("d?g");
            Assert.IsTrue(wc.IsMatch("dog"));
            Assert.IsTrue(wc.IsMatch("dug"));
            Assert.IsFalse(wc.IsMatch("cat"));
            Assert.IsFalse(wc.IsMatch("doggy"));
        }

        [TestMethod]
        public void TestUrlWildcards()
        {
            Wildcard wc = new Wildcard("*google.com*");
            Assert.IsTrue(wc.IsMatch("http://google.com"));
            Assert.IsTrue(wc.IsMatch("http://www.google.com"));
            Assert.IsTrue(wc.IsMatch("https://google.com"));
            Assert.IsTrue(wc.IsMatch("https://www.google.com"));
            Assert.IsTrue(wc.IsMatch("http://google.com/"));
            Assert.IsTrue(wc.IsMatch("http://www.google.com/"));
            Assert.IsTrue(wc.IsMatch("http://mail.google.com/"));
            Assert.IsFalse(wc.IsMatch("http://cnn.com"));
        }
    }
}
