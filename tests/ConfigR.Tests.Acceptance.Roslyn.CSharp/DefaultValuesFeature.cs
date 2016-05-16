// <copyright file="DefaultValuesFeature.cs" company="ConfigR contributors">
//  Copyright (c) ConfigR contributors. (configr.net@gmail.com)
// </copyright>

namespace ConfigR.Tests.Acceptance
{
    using System.IO;
    using ConfigR.Tests.Acceptance.Roslyn.CSharp.Support;
    using FluentAssertions;
    using Xbehave;

    public static class DefaultValuesFeature
    {
        [Scenario]
        public static void GettingAnExistingItem(int result)
        {
            dynamic config = null;

            "Given a config file with a Foo of 123"
                .f(c => ConfigFile.Create("Config.Foo = 123;").Using(c));

            "When I load the file"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().Load());

            "And I get Foo with a default of 456"
                .f(() => result = config.Foo<int>(456));

            "Then the result is 123"
                .f(() => result.Should().Be(123));
        }

        [Scenario]
        public static void GettingANonexistentItem(int result)
        {
            dynamic config = null;

            "Given a config file with a Foo of 123"
                .f(c => ConfigFile.Create("Config.Foo = 123;").Using(c));

            "When I load the file"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().Load());

            "And I get Bar with a default of 456"
                .f(() => result = config.Bar<int>(456));

            "Then the result is 456"
                .f(() => result.Should().Be(456));
        }
    }
}