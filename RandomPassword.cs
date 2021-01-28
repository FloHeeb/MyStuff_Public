using System;
using System.Management.Automation;


namespace FloStuff
{
    [Cmdlet(VerbsCommon.Get, "RandomPassword")]
    public class RandomPassword : PSCmdlet
    {
        [Parameter(Position = 0)]
        public int Lenght {set; get;}

        [Parameter(Position = 1)]
        public SwitchParameter NoSpecialCars {get; set;}

    }

    
}