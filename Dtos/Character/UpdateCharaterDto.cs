using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpn.Dtos.Character
{
    public class UpdateCharaterDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = "Frodo";
        public int HitPoints {get; set;} = 100;
        public int Strength {get; set;} = 10;
        public int Defence {get; set; } = 10;
        public int Inteligence {get; set;} = 10;
        public RgpClass Class {get; set;} = RgpClass.Knight;
    }
}