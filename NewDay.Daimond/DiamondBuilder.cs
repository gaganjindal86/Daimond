using System;
using System.Text;

namespace NewDayDaimond
{
    public class DiamondBuilder
    {
        private readonly Char _inputCharacter;
        private Int32 charIndex => _inputCharacter - 'A' + 1;
        private Int32 DiamondSize => charIndex * 2 - 1;
        private StringBuilder _daimond;  //purposely mutable string to minimise runtime memory usage

        public DiamondBuilder(Char inputCharacter)
        {
            _daimond = new StringBuilder();
            _inputCharacter = inputCharacter;
        }

        public String GetDaimond()
        {
            //Capture boundry case
            if (_inputCharacter == 'A') return "A";

            AddTopBottomLine();
            AddHalfDaimond();

            //Add middle line
            _daimond.AppendLine($"{_inputCharacter}{new String(' ', DiamondSize - 2)}{_inputCharacter}");

            AddHalfDaimond(bottomPart: true);
            AddTopBottomLine();

            return _daimond.ToString(); // returning Imutable string 
        }

        private void AddTopBottomLine()
        {
            _daimond.AppendLine($"{new String(' ', charIndex - 1)}A{new String(' ', charIndex - 1)}");
        }

        private void AddHalfDaimond(Boolean bottomPart = false)
        {
            StringBuilder halfDaimond = new StringBuilder();
            for (var i = 2; i < charIndex; i++)
            {
                Char charToUse = Convert.ToChar('A' + i - 1);
                Int32 leftRightPaddingCount = charIndex - 1 - (i - 1);
                var leftRightPadding = new String(' ', leftRightPaddingCount);
                var middlePaddingCount = DiamondSize - leftRightPaddingCount * 2 - 2;
                var middlePadding = new String(' ', middlePaddingCount);

                halfDaimond.AppendLine($"{leftRightPadding}{charToUse}{middlePadding}{charToUse}{leftRightPadding}");
            }

            if (halfDaimond.Length != 0)
            {
                if (bottomPart)
                {
                    var bottomHalf = halfDaimond.ToString().MultilineReverse();
                    _daimond.Append($"{bottomHalf}"); // Line break already added.
                }
                else
                {
                    _daimond.Append(halfDaimond.ToString()); // Line break already added.
                }
            }
        }
    }
}