using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnitLite;

namespace Starcounter.NUnit.Runner
{
    public class StarcounterNUnitRunner
    {
        private readonly Assembly callingAssembly;

        /// <summary>
        ///     NUnit runner for executing tests from the calling assembly using NUnitLite
        /// </summary>
        public StarcounterNUnitRunner()
        {
            callingAssembly = Assembly.GetCallingAssembly();
        }

        /// <summary>
        ///     Starts execution of test collection from calling assembly.
        /// </summary>
        /// <param name="testResultFullPath">
        ///     Full path to test result xml file. No file will be generated if unset.
        /// </param>
        public void Start(string testResultFullPath = null)
        {
            string[] args;
            if (string.IsNullOrEmpty(testResultFullPath))
            {
                args = new string[] { "--noresult", "--noheader" };
            }
            else
            {
                args = new string[] { $"--result={testResultFullPath}", "--noheader" };
            }

            Start(args);
        }

        /// <summary>
        ///     Starts execution of test collection from calling assembly. 
        /// </summary>
        /// <param name="args">
        ///     See argument options from https://github.com/nunit/docs/wiki/NUnitLite-Options
        /// </param>
        public void Start(string[] args)
        {
            var textRunner = new TextRunner(callingAssembly);
            int resultInt = textRunner.Execute(args);
        }
    }
}
