﻿namespace Nikse.SubtitleEdit.Core.Common.TextLengthCalculator
{
    public interface ICalcLength
    {
        decimal CountCharacters(string text, bool forCps);
    }
}