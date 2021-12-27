// See https://aka.ms/new-console-template for more information

using GameConsole;
using GameConsole.SpecialDefence;

var sam = new PlayerCharacter(new DiamondSkinDefence())
{
    Name = "Sam"
};

var john = new PlayerCharacter(new IronBonesDefence())
{
    Name = null
};

var defect = new PlayerCharacter(new NullDefence())
{
    Name = "defect"
};

sam.Hit(10);
john.Hit(14);
defect.Hit(10);
