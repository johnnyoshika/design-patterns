using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Bridge
{
    public abstract class Manuscript
    {
        public Manuscript(IFormatter formatter) => Formatter = formatter;

        protected IFormatter Formatter { get; }

        public abstract string Print();
    }

    public class Book : Manuscript
    {
        public Book(IFormatter formatter, string title, string author) : base(formatter) =>
            (Title, Author) = (title, author);

        public string Title { get; }
        public string Author { get; }

        public override string Print() => $"{Formatter.Format("Title", Title)} | {Formatter.Format("Author", Author)}";
    }

    public class TermPaper : Manuscript
    {
        public TermPaper(IFormatter formatter, string @class, string student, string text) : base(formatter) =>
            (Class, Student, Text) = (@class, student, text);

        public string Class { get; }
        public string Student { get; }
        public string Text { get; }

        public override string Print() => $"{Formatter.Format("Class", Class)} | {Formatter.Format("Student", Student)} | {Formatter.Format("Text", Text)}";
    }
}
