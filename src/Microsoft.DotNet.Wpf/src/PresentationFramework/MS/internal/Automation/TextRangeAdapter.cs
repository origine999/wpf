using System;
using System.Windows;
using System.Windows.Documents;

namespace MS.Internal.Automation
{
    internal class TextRangeAdapter
    {
        private TextPointer _start;
        private TextPointer _end;

        public TextRangeAdapter(TextPointer start, TextPointer end)
        {
            _start = start;
            _end = end;
        }

        public void ExpandToEnclosingUnit(TextUnit unit, bool expandStart, bool expandEnd)
        {
            if (unit == TextUnit.Line)
            {
                if (expandStart)
                {
                    _start = _start.GetLineStartPosition(0);
                }

                if (expandEnd)
                {
                    TextPointer lineEnd = _end.GetLineStartPosition(1);
                    if (lineEnd == null || _end.CompareTo(lineEnd) == 0)
                    {
                        _end = _end.GetLineStartPosition(0);
                    }
                    else
                    {
                        _end = lineEnd;
                    }
                }
            }
        }
    }

    internal enum TextUnit
    {
        Line
    }
}
