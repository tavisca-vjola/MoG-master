using System;
using System.Collections.Generic;

namespace MoG
{
    public class Language
    {
        private readonly List<IGrammer> _grammers = new List<IGrammer>()
        {
            new NumberAliasStatementGrammer(),
            new ItemPriceStatementGrammer(),
            new NumberConversionQuestionGrammer(),
            new ItemPriceQuoteQuestionGrammer()
        };

        public bool TryParse(string text, out ISentence stmt)
        {
            stmt = null;
            foreach( var grammer in _grammers )
            {
                if (grammer.TryParse(text, out stmt) == true)
                    return true;
            }
            return false;
        }

        public bool TryParseNumberConversionQuestion(string text, out NumberConversionQuestion stmt)
        {
            // text must be of the form "how much is pish glob ?".
            // Should start with how much is
            // Must end in ?
            // Everthing in between is the number
            stmt = null;
            if (text.StartsWith("how much is ", StringComparison.Ordinal) == false)
                return false;
            if (text.EndsWith("?", StringComparison.Ordinal) == false)
                return false;
            var number = text
                            .Replace("how much is ", string.Empty)
                            .Replace(" ?", string.Empty);
            stmt = new NumberConversionQuestion(number);
            return true;
        }
    }
}
