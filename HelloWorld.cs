using System;
using System.Management.Automation;

namespace MyFirstModule
{
    [Cmdlet(VerbsCommon.Get, "PersInfo")]
    [OutputType(typeof(OutputObject))]
    public class HelloWorld : PSCmdlet
    {
        [Alias("Username")]
        [Parameter(Position = 0,ValueFromPipeline = true)]
        public string Name { get; set; }

        [Parameter(Position = 1)]
        public SwitchParameter Option {get; set;}

        protected override void BeginProcessing()
        {
            WriteVerbose("Begin");
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Process");
            var greeting = "Hello " + (string.IsNullOrEmpty(Name) ? "Mister X" : Name);
            Console.WriteLine(greeting);
            if (string.IsNullOrEmpty(Name)) {
                WriteVerbose("Set name to Mister X");
                Name = "Mister X";
            }
            Random MyID = new Random();
            var Output = new OutputObject();
            Output.Name = Name;
            Output.ID = MyID.Next(10,99);
            Output.LastSeen = DateTime.Now;
            Output.Status = Option;

            WriteObject(Output);
        }

        protected override void EndProcessing()
        {
            WriteVerbose("Ende der Geschichte..");
        }
    }
    public class OutputObject
    {
        public string Name {get; set;}
        public int ID {get; set;}
        public DateTime LastSeen {get; set;}
        public bool Status {get; set;}
    }
}
