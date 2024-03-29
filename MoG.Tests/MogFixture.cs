﻿using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace MoG.Tests
{
    public class MogFixture
    {
        public MogFixture(ITestOutputHelper console)
        {
            _console = console;
        }

        private ITestOutputHelper _console;

        [Fact]
        public void Basic_merchant_script_test()
        {
            var dialogues = new string[]
            {
                "glob is I",
                "prok is V",
                "pish is X",
                "tegj is L",
                "glob glob Silver is 34 Credits",
                "glob prok Gold is 57800 Credits",
                "pish pish Iron is 3910 Credits",
                "how much is pish tegj glob glob ?",
                "how many Credits is glob prok Silver ?",
                "how many Credits is glob prok Gold ?",
                "how many Credits is glob prok Iron ?",
                "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"
            };

            var expectedResponses = new string[]
            {
                "pish tegj glob glob is 42.",
                "glob prok Silver is 68 Credits",
                "glob prok Gold is 57800 Credits",
                "glob prok Iron is 782 Credits",
                "I have no idea what you are talking about"

            };
            var script = new IntergalacticScript();
            var responses = script.PlayScript(dialogues);
            responses.Should().IntersectWith(expectedResponses);

        }

    }
}
