﻿using System;

using SpellChecker.Contracts;

namespace SpellChecker.Core
{

    /// <summary>
    /// This spell checker implements the following rule:
    /// "I before E, except after C" is a mnemonic rule of thumb for English spelling.
    /// If one is unsure whether a word is spelled with the sequence ei or ie, the rhyme
    /// suggests that the correct order is ie unless the preceding letter is c, in which case it is ei.
    /// 
    /// Examples: believe, fierce, collie, die, friend, deceive, ceiling, receipt would be evaulated as spelled correctly
    /// heir, protein, science, seeing, their, and veil would be evaluated as spelled incorrectly.
    /// </summary>
    public class MnemonicSpellCheckerIBeforeE :
        ISpellChecker
    {

        /// <summary>
        /// Returns false if the word contains a letter sequence of "ie" when it is immediately preceded by c.
        /// </summary>
        /// <param name="word">The word to be checked</param>
        /// <returns>true when the word is spelled correctly, false otherwise</returns>
        public bool Check(string word)
        {
            // Check if the string ei and ie are in the word
            // If they are, check each for their valid mneumonic rule
            // else just let the word pass/(return true) as it will get handled by dictionary spell checker 
            if (word.Contains("ei"))
            {
                if (word.Contains("cei"))
                {
                    return true;
                }
            }
            if (word.Contains("ie"))
            {
                if (word.Contains("cie"))
                {
                    return false;
                }
            }
            return true;
        }

    }

}
