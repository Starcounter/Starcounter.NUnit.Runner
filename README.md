# Starcounter.NUnit.Runner
`NUnit` console runner for executing tests in the same domain as the Starcounter database which makes it possible to use any of the Starcounter platform functionality within a test. Hence, it fills the gap where Starcounter version `2.3` lacks the functionality to connect to the Starcounter database programmatically, also known as Self-hosting apps. 

## How to use it
* Create a normal Starcounter App, version 2.3. Make sure it targets `.NET Framework 4.5.2` or above.
* Add reference to `StarcounterNUnitRunner.dll` through nuget: `Install-Package Starcounter.NUnit.Runner`
* Set `<CopyToOutputDirectory>Always</CopyToOutputDirectory>` for the added `weaver.ignore` content file. 
* Include namespace `Starcounter.NUnit.Runner` and create an instance of `StarcounterNUnitRunner` in `Main()`
```c#
StarcounterNUnitRunner runner = new StarcounterNUnitRunner();
runner.Start();
```
* Write NUnit 3 tests, please see the [documentation](https://github.com/nunit/docs/wiki) on how to write tests.
* Any time the Starcounter database is accessed, the code needs to be wrapped around 
```c#
Scheduling.ScheduleTask(() => 
{ 
    /* Test code here */
}, waitForCompletion: true);
```
Make sure to set `waitForCompletion = true` because `NUnit` may execute tests in parallel.
* Compile and deploy the Starcounter test App as any other Starcounter App, `star.exe <StarcounterTestApp>.exe`. The test result should be displayed in the console.

## StarcounterNUnitRunner
Using:
* .NET Framework 4.5.2
* nunit.framework 3.7.1
* nunitlite 3.7.1

A `NUnit` runner which executes tests as a NUnit console application in the same AppDomain as the Starcounter database. 

### Starcounter.NUnit.Runner.StarcounterNUnitRunner API
```c#
//
// Summary:
//     NUnit runner for executing tests from the calling assembly using NUnitLite
public StarcounterNUnitRunner();

//
// Summary:
//     Starts execution of test collection from calling assembly.
//
// Parameters:
//   testResultFullPath:
//     Full path to test result xml file. No file will be generated if unset.
public void Start(string testResultFullPath = null);

//
// Summary:
//     Starts execution of test collection from calling assembly.
//
// Parameters:
//   args:
//     See argument options from https://github.com/nunit/docs/wiki/NUnitLite-Options
public void Start(string[] args);
```

## Demo\ScTestApp
A Starcounter version `2.3` test App which references `StarcounterNUnitRunner`. It illustrates how to use `StarcounterNUnitRunner` together with an App which contains a Starcounter database, `ScApp.ScAppDb`.

Using:
* .NET Framework 4.5.2
* Starcounter 2.3.*
* StarcounterNUnitRunner 1.0.0
* nunit.framework 3.7.1

Test result from running `star.exe ScTestApp.exe`.
```
Errors, Failures and Warnings
1) Failed : ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_1
  This assertion will always fail
  Expected: True
  But was:  False
at ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_1() in C:\Starcounter.NUnit.Runner\Demo\ScTestApp\TestSetAlwaysFailing.cs:line 16

2) Failed : ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_2
  This assertion will always fail
  Expected: True
  But was:  False
at ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_2() in C:\Starcounter.NUnit.Runner\Demo\ScTestApp\TestSetAlwaysFailing.cs:line 22

3) Failed : ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_3
  This assertion will always fail
  Expected: True
  But was:  False
at ScTestApp.TestSetAlwaysFailing.TestCase_AlwaysFailing_3() in C:\Starcounter.NUnit.Runner\Demo\ScTestApp\TestSetAlwaysFailing.cs:line 28

Run Settings
    Number of Test Workers: 8
    Internal Trace: OffProgram Files\Starcounter


Test Run Summary
  Overall result: Failed
  Test Count: 9, Passed: 6, Failed: 3, Warnings: 0, Inconclusive: 0, Skipped: 0
  Failed Tests - Failures: 3, Errors: 0, Invalid: 0
  Start time: 2017-08-12 14:20:09Z
  End time: 2017-08-12 14:20:10Z
  Duration: 0.082 seconds
```

## Demo\ScApp
A dummy Starcounter version `2.3` App which only has one database-table. Used for testing purposes only.
```c#
[Database]
public class ScAppDb
{
    public string Name { get; set; }
    public int Integer { get; set; }
    public DateTime DateCreated { get; set; }
}
```

It has handlers for the following
* `/ScApp/CreateNewEntry` - create a new row with random data
* `/ScApp/CreateNewEntry/<# of new entries>` - create multiple new rows with random data
* `/ScApp/DeleteAll` - delete all rows
* `/ScApp/ListAll` - list all rows in text format