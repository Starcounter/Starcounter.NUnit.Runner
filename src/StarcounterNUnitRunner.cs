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
        public string testResultFullPath = null;
        // TODO: add field for nunit console arguments, https://github.com/nunit/docs/wiki/NUnitLite-Options

        public StarcounterNUnitRunner()
        {
            callingAssembly = Assembly.GetCallingAssembly();
        }

        public void Start()
        {
            var textRunner = new TextRunner(callingAssembly);
            int resultInt = 0;
            string[] args;
            if (string.IsNullOrEmpty(testResultFullPath))
            {
                args = new string[] { "--noresult" };
                //args = new string[] { "--noheader", "--noresult" };
                //args = new string[] { "--explore" };
            }
            else
            {
                args = new string[] { $"--result={testResultFullPath}" };
            }

            resultInt = textRunner.Execute(args);
        }
    }
}
