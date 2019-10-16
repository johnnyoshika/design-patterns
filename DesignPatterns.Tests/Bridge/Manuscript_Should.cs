using DesignPatterns.Bridge;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Bridge
{
    public class Manuscript_Should
    {
        // IFormatter bridge allows us to replace the formatter to change the print formatting
        // without changing any other code.

        // Common usages:
        // - Drawing API for shapes
        // - Persistent types for objects
        // - .Net Provider Model

        [Fact]
        public void Use_IFormatter_As_Bridge_For_Standard_Formatting()
        {
            var standardFormatter = new Mock<IFormatter>();
            standardFormatter.Setup(f => f.Format(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((key, value) => $"{key}: {value}");

            var manuscripts = new List<Manuscript>
            {
                new Book(standardFormatter.Object, "Hamlet", "Shakespeare"),
                new TermPaper(standardFormatter.Object, "History", "Bob", "Lorem ipsum dolor sit amet")
            };

            Assert.Equal("Title: Hamlet | Author: Shakespeare", manuscripts.ElementAt(0).Print());
            Assert.Equal("Class: History | Student: Bob | Text: Lorem ipsum dolor sit amet", manuscripts.ElementAt(1).Print());
        }

        [Fact]
        public void Use_IFormatter_As_Bridge_For_Backwards_Formatting()
        {
            var backwardsFormatter = new Mock<IFormatter>();
            backwardsFormatter.Setup(f => f.Format(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((key, value) => $"{key}: {new string(value.Reverse().ToArray())}");

            var manuscripts = new List<Manuscript>
            {
                new Book(backwardsFormatter.Object, "Hamlet", "Shakespeare"),
                new TermPaper(backwardsFormatter.Object, "History", "Bob", "Lorem ipsum dolor sit amet")
            };

            Assert.Equal("Title: telmaH | Author: eraepsekahS", manuscripts.ElementAt(0).Print());
            Assert.Equal("Class: yrotsiH | Student: boB | Text: tema tis rolod muspi meroL", manuscripts.ElementAt(1).Print());
        }

        [Fact]
        public void Use_IFormatter_As_Bridge_For_Fancy_Formatting()
        {
            var fancyFormatter = new Mock<IFormatter>();
            fancyFormatter.Setup(f => f.Format(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((key, value) => $"#{key}# - {value}");

            var manuscripts = new List<Manuscript>
            {
                new Book(fancyFormatter.Object, "Hamlet", "Shakespeare"),
                new TermPaper(fancyFormatter.Object, "History", "Bob", "Lorem ipsum dolor sit amet")
            };

            Assert.Equal("#Title# - Hamlet | #Author# - Shakespeare", manuscripts.ElementAt(0).Print());
            Assert.Equal("#Class# - History | #Student# - Bob | #Text# - Lorem ipsum dolor sit amet", manuscripts.ElementAt(1).Print());
        }
    }
}
