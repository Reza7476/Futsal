using Futsal.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Entities.Teams;
public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ColorDress ColorDressOrigin { get; set; }
    public ColorDress ColorDressNormal { get; set; }
    
   
    public List<Player> Players { get; set; }
}


public enum ColorDress
{
    White,
    Red,
    Blue,
    Yellow
}